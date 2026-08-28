import { Component, signal, computed, ElementRef, ViewChild, AfterViewChecked, NgZone } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

interface ChatMsg {
  role: 'user' | 'assistant';
  content: string;
}

@Component({
  selector: 'app-chatbot',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressBarModule,
  ],
  template: `
    <!-- FAB Button -->
    <button
      class="chatbot-fab bgn-press"
      (click)="toggleChat()"
      [attr.aria-label]="isOpen() ? 'Close chat' : 'Open Blood Buddy chat'"
    >
      @if (isOpen()) {
        <mat-icon>close</mat-icon>
      } @else {
        <svg viewBox="0 0 24 24" width="28" height="28" fill="currentColor" aria-hidden="true">
          <path d="M12 2.5s7 5.8 7 11.2A7 7 0 1 1 5 13.7C5 8.3 12 2.5 12 2.5z"/>
        </svg>
      }
    </button>

    <!-- Chat Window -->
    @if (isOpen()) {
      <div class="chatbot-window">
        <div class="chatbot-header">
          <div class="header-info">
            <svg class="header-icon" viewBox="0 0 24 24" width="22" height="22" fill="currentColor" aria-hidden="true">
              <path d="M12 2.5s7 5.8 7 11.2A7 7 0 1 1 5 13.7C5 8.3 12 2.5 12 2.5z"/>
            </svg>
            <div>
              <div class="header-title">Blood Buddy</div>
              <div class="header-subtitle">AI Assistant</div>
            </div>
          </div>
          <button mat-icon-button (click)="toggleChat()" aria-label="Close chat">
            <mat-icon>close</mat-icon>
          </button>
        </div>

        <div class="chatbot-hint">
          Type in English, Bangla, or Banglish!
        </div>

        <div class="chatbot-messages" #messagesContainer>
          @for (msg of messages(); track $index) {
            <div class="message bgn-fade-up" [class.user]="msg.role === 'user'" [class.assistant]="msg.role === 'assistant'">
              <div class="bubble">{{ msg.content }}</div>
            </div>
          }
          @if (loading()) {
            <div class="message assistant">
              <div class="bubble typing-indicator">
                <span></span><span></span><span></span>
              </div>
            </div>
          }
        </div>

        <div class="chatbot-input-area">
          <mat-form-field appearance="outline" class="chat-input-field">
            <input
              matInput
              [(ngModel)]="userInput"
              (keydown.enter)="sendMessage()"
              (compositionstart)="onCompositionStart()"
              (compositionend)="onCompositionEnd($event)"
              placeholder="Ask about blood donation..."
              maxlength="500"
              [disabled]="loading()"
              #inputField
            />
          </mat-form-field>
          <button
            mat-fab
            color="primary"
            (click)="sendMessage()"
            [disabled]="!userInput.trim() || loading()"
            aria-label="Send message"
            class="send-btn bgn-press"
          >
            <mat-icon>send</mat-icon>
          </button>
        </div>
      </div>
    }
  `,
  styles: [`
    :host { display: contents; }

    .chatbot-fab {
      position: fixed;
      bottom: 24px;
      right: 24px;
      z-index: 1000;
      width: 60px;
      height: 60px;
      border-radius: 50%;
      border: none;
      background: var(--bgn-gradient);
      color: #fff;
      cursor: pointer;
      display: flex;
      align-items: center;
      justify-content: center;
      box-shadow: var(--bgn-shadow-lg);
      transition: transform 0.2s ease, box-shadow 0.2s ease;
    }
    .chatbot-fab:hover {
      transform: scale(1.08);
      box-shadow: 0 8px 32px rgba(229, 57, 53, 0.35);
    }
    .chatbot-fab mat-icon { font-size: 28px; width: 28px; height: 28px; }

    .chatbot-window {
      position: fixed;
      bottom: 96px;
      right: 24px;
      z-index: 999;
      width: 380px;
      height: 500px;
      background: var(--bgn-surface);
      border: 1px solid var(--bgn-border);
      border-radius: var(--bgn-radius-md);
      box-shadow: var(--bgn-shadow-lg);
      display: flex;
      flex-direction: column;
      overflow: hidden;
      transform-origin: bottom right;
      animation: slideUp 0.3s cubic-bezier(0.16, 1, 0.3, 1);
    }

    @keyframes slideUp {
      from { opacity: 0; transform: translateY(16px) scale(0.97); }
      to { opacity: 1; transform: translateY(0) scale(1); }
    }

    .chatbot-header {
      display: flex;
      align-items: center;
      justify-content: space-between;
      padding: 14px 16px;
      background: var(--bgn-gradient);
      color: #fff;
    }
    .header-info { display: flex; align-items: center; gap: 10px; }
    .header-icon { flex-shrink: 0; }
    .header-title { font-weight: 700; font-size: 1rem; }
    .header-subtitle { font-size: 0.75rem; opacity: 0.85; }
    .chatbot-header button { color: #fff !important; }

    .chatbot-hint {
      text-align: center;
      font-size: 0.75rem;
      color: var(--bgn-text-faint);
      padding: 6px 0 0;
      background: var(--bgn-surface);
    }

    .chatbot-messages {
      flex: 1;
      overflow-y: auto;
      padding: 12px 14px;
      display: flex;
      flex-direction: column;
      gap: 8px;
      background: var(--bgn-surface-2);
    }

    .message {
      display: flex;
    }
    .message.user { justify-content: flex-end; }
    .message.assistant { justify-content: flex-start; }

    .bubble {
      max-width: 80%;
      padding: 10px 14px;
      border-radius: var(--bgn-radius-md);
      font-size: 0.9rem;
      line-height: 1.45;
      white-space: pre-wrap;
      word-break: break-word;
    }
    .message.user .bubble {
      background: var(--bgn-primary);
      color: #fff;
      border-bottom-right-radius: 4px;
    }
    .message.assistant .bubble {
      background: var(--bgn-surface);
      color: var(--bgn-text);
      border: 1px solid var(--bgn-border);
      border-bottom-left-radius: 4px;
    }

    .typing-indicator {
      display: flex;
      gap: 4px;
      align-items: center;
      padding: 12px 18px !important;
    }
    .typing-indicator span {
      width: 7px;
      height: 7px;
      border-radius: 50%;
      background: var(--bgn-text-faint);
      animation: typingBounce 1.2s infinite ease-in-out;
    }
    .typing-indicator span:nth-child(2) { animation-delay: 0.2s; }
    .typing-indicator span:nth-child(3) { animation-delay: 0.4s; }

    @keyframes typingBounce {
      0%, 60%, 100% { transform: translateY(0); opacity: 0.4; }
      30% { transform: translateY(-5px); opacity: 1; }
    }

    .chatbot-input-area {
      display: flex;
      align-items: center;
      gap: 8px;
      padding: 8px 12px;
      border-top: 1px solid var(--bgn-border);
      background: var(--bgn-surface);
    }

    .chat-input-field {
      flex: 1;
    }
    .chat-input-field ::ng-deep .mat-mdc-text-field-wrapper {
      border-radius: var(--bgn-radius-pill) !important;
    }
    .chat-input-field ::ng-deep .mat-mdc-form-field-subscript-wrapper {
      display: none;
    }

    .send-btn {
      width: 44px !important;
      height: 44px !important;
      flex-shrink: 0;
    }

    @media (max-width: 480px) {
      .chatbot-window {
        right: 8px;
        left: 8px;
        bottom: 80px;
        width: auto;
        height: 60vh;
      }
      .chatbot-fab {
        bottom: 16px;
        right: 16px;
      }
    }
  `]
})
export class ChatbotComponent implements AfterViewChecked {
  @ViewChild('messagesContainer') messagesContainer!: ElementRef<HTMLDivElement>;

  isOpen = signal(false);
  loading = signal(false);
  messages = signal<ChatMsg[]>([
    {
      role: 'assistant',
      content: 'How can I help you?',
    },
  ]);

  userInput = '';
  isComposing = false;
  private shouldScroll = false;
  private apiUrl = `${environment.apiUrl}/chat`;

  constructor(private http: HttpClient, private ngZone: NgZone) {}

  ngAfterViewChecked(): void {
    if (this.shouldScroll) {
      this.scrollToBottom();
      this.shouldScroll = false;
    }
  }

  toggleChat(): void {
    this.isOpen.update((v) => !v);
    if (this.isOpen()) {
      this.shouldScroll = true;
    }
  }

  onCompositionStart(): void {
    this.isComposing = true;
  }

  onCompositionEnd(event: CompositionEvent): void {
    this.isComposing = false;
    const target = event.target as HTMLInputElement;
    this.userInput = target.value;
  }

  sendMessage(): void {
    if (this.isComposing) return;
    const text = this.userInput.trim();
    if (!text || this.loading()) return;

    this.messages.update((msgs) => [...msgs, { role: 'user', content: text }]);
    this.userInput = '';
    this.loading.set(true);
    this.shouldScroll = true;

    const history = this.messages()
      .slice(-20)
      .map((m) => ({ Role: m.role === 'user' ? 'User' : 'Assistant', Content: m.content }));

    this.http
      .post<{ reply: string }>(this.apiUrl, { message: text, history })
      .subscribe({
        next: (res) => {
          this.messages.update((msgs) => [...msgs, { role: 'assistant', content: res.reply }]);
          this.loading.set(false);
          this.shouldScroll = true;
        },
        error: () => {
          this.messages.update((msgs) => [
            ...msgs,
            {
              role: 'assistant',
              content:
                'Sorry, something went wrong. Please try again later.\nদুঃখিত, কিছু ভুল হয়েছে। পরে আবার চেষ্টা করুন।',
            },
          ]);
          this.loading.set(false);
          this.shouldScroll = true;
        },
      });
  }

  private scrollToBottom(): void {
    try {
      const el = this.messagesContainer?.nativeElement;
      if (el) {
        el.scrollTop = el.scrollHeight;
      }
    } catch {}
  }
}
