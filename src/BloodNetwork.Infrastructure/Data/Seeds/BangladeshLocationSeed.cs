using BloodNetwork.Domain.Entities;

namespace BloodNetwork.Infrastructure.Data.Seeds;

public static class BangladeshLocationSeed
{
    // Fixed, deterministic timestamp so EF Core HasData snapshots stay stable
    // across consecutive 'dotnet ef migrations add' runs (avoids regenerating
    // UpdateData for every seeded row just because DateTime.UtcNow changed).
    private static readonly DateTime SeedTimestamp = new(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc);

    public static List<Division> GetDivisions()
    {
        var list = new List<Division>
        {
            new() { Id = new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), Name = "Dhaka", NameBn = "ঢাকা" },
            new() { Id = new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), Name = "Chattogram", NameBn = "চট্টগ্রাম" },
            new() { Id = new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), Name = "Rajshahi", NameBn = "রাজশাহী" },
            new() { Id = new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), Name = "Khulna", NameBn = "খুলনা" },
            new() { Id = new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), Name = "Barishal", NameBn = "বরিশাল" },
            new() { Id = new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), Name = "Sylhet", NameBn = "সিলেট" },
            new() { Id = new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), Name = "Rangpur", NameBn = "রংপুর" },
            new() { Id = new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), Name = "Mymensingh", NameBn = "ময়মনসিংহ" },
        };
        foreach (var d in list) { d.CreatedAt = SeedTimestamp; d.UpdatedAt = null; }
        return list;
    }

    public static List<District> GetDistricts()
    {
        var divisions = GetDivisions();
        var dhakaId = divisions.First(d => d.Name == "Dhaka").Id;
        var chattogramId = divisions.First(d => d.Name == "Chattogram").Id;
        var rajshahiId = divisions.First(d => d.Name == "Rajshahi").Id;
        var khulnaId = divisions.First(d => d.Name == "Khulna").Id;
        var barishalId = divisions.First(d => d.Name == "Barishal").Id;
        var sylhetId = divisions.First(d => d.Name == "Sylhet").Id;
        var rangpurId = divisions.First(d => d.Name == "Rangpur").Id;
        var mymensinghId = divisions.First(d => d.Name == "Mymensingh").Id;

        var list = new List<District>
        {
            // Dhaka Division
            new() { Id = new Guid("11111111-1111-4111-8111-111111111101"), DivisionId = dhakaId, Name = "Dhaka", NameBn = "ঢাকা" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111102"), DivisionId = dhakaId, Name = "Gazipur", NameBn = "গাজীপুর" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111103"), DivisionId = dhakaId, Name = "Narayanganj", NameBn = "নারায়ণগঞ্জ" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111104"), DivisionId = dhakaId, Name = "Manikganj", NameBn = "মানিকগঞ্জ" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111105"), DivisionId = dhakaId, Name = "Munshiganj", NameBn = "মুন্সিগঞ্জ" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111106"), DivisionId = dhakaId, Name = "Tangail", NameBn = "টাঙ্গাইল" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111107"), DivisionId = dhakaId, Name = "Kishoreganj", NameBn = "কিশোরগঞ্জ" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111108"), DivisionId = dhakaId, Name = "Faridpur", NameBn = "ফরিদপুর" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111109"), DivisionId = dhakaId, Name = "Gopalganj", NameBn = "গোপালগঞ্জ" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111110"), DivisionId = dhakaId, Name = "Madaripur", NameBn = "মাদারীপুর" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111111"), DivisionId = dhakaId, Name = "Rajbari", NameBn = "রাজবাড়ী" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111112"), DivisionId = dhakaId, Name = "Narsingdi", NameBn = "নরসিংদী" },
            new() { Id = new Guid("11111111-1111-4111-8111-111111111113"), DivisionId = dhakaId, Name = "Shariatpur", NameBn = "শরীয়তপুর" },
            // Chattogram Division
            new() { Id = new Guid("22222222-2222-4222-8222-222222222201"), DivisionId = chattogramId, Name = "Chattogram", NameBn = "চট্টগ্রাম" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222202"), DivisionId = chattogramId, Name = "Cox's Bazar", NameBn = "কক্সবাজার" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222203"), DivisionId = chattogramId, Name = "Comilla", NameBn = "কুমিল্লা" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222204"), DivisionId = chattogramId, Name = "Brahmanbaria", NameBn = "ব্রাহ্মণবাড়িয়া" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222205"), DivisionId = chattogramId, Name = "Chandpur", NameBn = "চাঁদপুর" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222206"), DivisionId = chattogramId, Name = "Lakshmipur", NameBn = "লক্ষ্মীপুর" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222207"), DivisionId = chattogramId, Name = "Noakhali", NameBn = "নোয়াখালী" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222208"), DivisionId = chattogramId, Name = "Feni", NameBn = "ফেনী" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222209"), DivisionId = chattogramId, Name = "Khagrachhari", NameBn = "খাগড়াছড়ি" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222210"), DivisionId = chattogramId, Name = "Rangamati", NameBn = "রাঙ্গামাটি" },
            new() { Id = new Guid("22222222-2222-4222-8222-222222222211"), DivisionId = chattogramId, Name = "Bandarban", NameBn = "বান্দরবান" },
            // Rajshahi Division
            new() { Id = new Guid("33333333-3333-4333-8333-333333333301"), DivisionId = rajshahiId, Name = "Rajshahi", NameBn = "রাজশাহী" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333302"), DivisionId = rajshahiId, Name = "Natore", NameBn = "নাটোর" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333303"), DivisionId = rajshahiId, Name = "Bogura", NameBn = "বগুড়া" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333304"), DivisionId = rajshahiId, Name = "Chapainawabganj", NameBn = "চাঁপাইনবাবগঞ্জ" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333305"), DivisionId = rajshahiId, Name = "Naogaon", NameBn = "নওগাঁ" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333306"), DivisionId = rajshahiId, Name = "Sirajganj", NameBn = "সিরাজগঞ্জ" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333307"), DivisionId = rajshahiId, Name = "Pabna", NameBn = "পাবনা" },
            new() { Id = new Guid("33333333-3333-4333-8333-333333333308"), DivisionId = rajshahiId, Name = "Joypurhat", NameBn = "জয়পুরহাট" },
            // Khulna Division
            new() { Id = new Guid("44444444-4444-4444-8444-444444444401"), DivisionId = khulnaId, Name = "Khulna", NameBn = "খুলনা" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444402"), DivisionId = khulnaId, Name = "Satkhira", NameBn = "সাতক্ষীরা" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444403"), DivisionId = khulnaId, Name = "Jessore", NameBn = "যশোর" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444404"), DivisionId = khulnaId, Name = "Bagerhat", NameBn = "বাগেরহাট" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444405"), DivisionId = khulnaId, Name = "Jhenaidah", NameBn = "ঝিনাইদহ" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444406"), DivisionId = khulnaId, Name = "Magura", NameBn = "মাগুরা" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444407"), DivisionId = khulnaId, Name = "Narail", NameBn = "নড়াইল" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444408"), DivisionId = khulnaId, Name = "Kushtia", NameBn = "কুষ্টিয়া" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444409"), DivisionId = khulnaId, Name = "Meherpur", NameBn = "মেহেরপুর" },
            new() { Id = new Guid("44444444-4444-4444-8444-444444444410"), DivisionId = khulnaId, Name = "Chuadanga", NameBn = "চুয়াডাঙ্গা" },
            // Barishal Division
            new() { Id = new Guid("55555555-5555-4555-8555-555555555501"), DivisionId = barishalId, Name = "Barishal", NameBn = "বরিশাল" },
            new() { Id = new Guid("55555555-5555-4555-8555-555555555502"), DivisionId = barishalId, Name = "Patuakhali", NameBn = "পটুয়াখালী" },
            new() { Id = new Guid("55555555-5555-4555-8555-555555555503"), DivisionId = barishalId, Name = "Bhola", NameBn = "ভোলা" },
            new() { Id = new Guid("55555555-5555-4555-8555-555555555504"), DivisionId = barishalId, Name = "Pirojpur", NameBn = "পিরোজপুর" },
            new() { Id = new Guid("55555555-5555-4555-8555-555555555505"), DivisionId = barishalId, Name = "Jhalakathi", NameBn = "ঝালকাঠি" },
            new() { Id = new Guid("55555555-5555-4555-8555-555555555506"), DivisionId = barishalId, Name = "Barguna", NameBn = "বরগুনা" },
            // Sylhet Division
            new() { Id = new Guid("66666666-6666-4666-8666-666666666601"), DivisionId = sylhetId, Name = "Sylhet", NameBn = "সিলেট" },
            new() { Id = new Guid("66666666-6666-4666-8666-666666666602"), DivisionId = sylhetId, Name = "Habiganj", NameBn = "হবিগঞ্জ" },
            new() { Id = new Guid("66666666-6666-4666-8666-666666666603"), DivisionId = sylhetId, Name = "Moulvibazar", NameBn = "মৌলভীবাজার" },
            new() { Id = new Guid("66666666-6666-4666-8666-666666666604"), DivisionId = sylhetId, Name = "Sunamganj", NameBn = "সুনামগঞ্জ" },
            // Rangpur Division
            new() { Id = new Guid("77777777-7777-4777-8777-777777777701"), DivisionId = rangpurId, Name = "Rangpur", NameBn = "রংপুর" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777702"), DivisionId = rangpurId, Name = "Dinajpur", NameBn = "দিনাজপুর" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777703"), DivisionId = rangpurId, Name = "Thakurgaon", NameBn = "ঠাকুরগাঁও" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777704"), DivisionId = rangpurId, Name = "Kurigram", NameBn = "কুড়িগ্রাম" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777705"), DivisionId = rangpurId, Name = "Gaibandha", NameBn = "গাইবান্ধা" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777706"), DivisionId = rangpurId, Name = "Lalmonirhat", NameBn = "লালমনিরহাট" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777707"), DivisionId = rangpurId, Name = "Nilphamari", NameBn = "নীলফামারী" },
            new() { Id = new Guid("77777777-7777-4777-8777-777777777708"), DivisionId = rangpurId, Name = "Panchagarh", NameBn = "পঞ্চগড়" },
            // Mymensingh Division
            new() { Id = new Guid("88888888-8888-4888-8888-888888888801"), DivisionId = mymensinghId, Name = "Mymensingh", NameBn = "ময়মনসিংহ" },
            new() { Id = new Guid("88888888-8888-4888-8888-888888888802"), DivisionId = mymensinghId, Name = "Jamalpur", NameBn = "জামালপুর" },
            new() { Id = new Guid("88888888-8888-4888-8888-888888888803"), DivisionId = mymensinghId, Name = "Sherpur", NameBn = "শেরপুর" },
            new() { Id = new Guid("88888888-8888-4888-8888-888888888804"), DivisionId = mymensinghId, Name = "Netrokona", NameBn = "নেত্রকোণা" },
        };
        foreach (var d in list) { d.CreatedAt = SeedTimestamp; d.UpdatedAt = null; }
        return list;
    }

    public static List<Upazila> GetUpazilas()
    {
        var districts = GetDistricts();

        var list = new List<Upazila>
        {
            // Dhaka District
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Savar", NameBn = "সাভার" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Dhamrai", NameBn = "ধামরাই" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Dohar", NameBn = "দোহার" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Keraniganj", NameBn = "কেরাণীগঞ্জ" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Nawabganj", NameBn = "নবাবগঞ্জ" },

            // Dhaka Metropolitan (North/South City) thanas
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Uttara", NameBn = "উত্তরা" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Gulshan", NameBn = "গুলশান" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Banani", NameBn = "বনানী" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000014"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Badda", NameBn = "বাড্ডা" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000015"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Khilgaon", NameBn = "খিলগাঁও" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000016"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Rampura", NameBn = "রামপুরা" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000017"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Mirpur", NameBn = "মিরপুর" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000018"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Pallabi", NameBn = "পল্লবী" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000019"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Kafrul", NameBn = "কাফরুল" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000020"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Cantonment", NameBn = "ক্যান্টনমেন্ট" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000021"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Tejgaon", NameBn = "তেজগাঁও" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000022"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Mohammadpur", NameBn = "মোহাম্মদপুর" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000023"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Dhanmondi", NameBn = "ধানমন্ডি" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000024"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Shahbagh", NameBn = "শাহবাগ" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000025"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Ramna", NameBn = "রমনা" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000026"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Motijheel", NameBn = "মতিঝিল" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000027"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Paltan", NameBn = "পল্টন" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000028"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Sabujbagh", NameBn = "সবুজবাগ" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000029"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Lalbagh", NameBn = "লালবাগ" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000030"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Kotwali", NameBn = "কোতয়ালী" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000031"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Sutrapur", NameBn = "সূত্রাপুর" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000032"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Hazaribagh", NameBn = "হাজারীবাগ" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000033"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Demra", NameBn = "ডেমরা" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000034"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Jatrabari", NameBn = "যাত্রাবাড়ী" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000035"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Kamrangirchar", NameBn = "কামরাঙ্গীরচর" },

            // Gazipur District
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Gazipur Sadar", NameBn = "গাজীপুর সদর" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Tongi", NameBn = "টঙ্গী" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Kaliakair", NameBn = "কালিয়াইর" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Kaliganj", NameBn = "কালীগঞ্জ" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Kapasia", NameBn = "কাপাসিয়া" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Sreepur", NameBn = "শ্রীপুর" },

            // Narayanganj District
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Narayanganj Sadar", NameBn = "নারায়ণগঞ্জ সদর" },
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Sonargaon", NameBn = "সোনারগাঁও" },
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Bandar", NameBn = "বন্দর" },
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Araihazar", NameBn = "আড়াইহাজার" },
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Rupganj", NameBn = "রূপগঞ্জ" },

            // Manikganj District
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Manikganj Sadar", NameBn = "মানিকগঞ্জ সদর" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Singair", NameBn = "সিঙ্গাইর" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Daulatpur", NameBn = "দৌলতপুর" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Ghior", NameBn = "ঘিওর" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Harirampur", NameBn = "হরিরামপুর" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Saturia", NameBn = "সাটুরিয়া" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Shibalay", NameBn = "শিবালয়" },

            // Munshiganj District
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Munshiganj Sadar", NameBn = "মুন্সিগঞ্জ সদর" },
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Sreenagar", NameBn = "শ্রীনগর" },
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Gazaria", NameBn = "গজারিয়া" },
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Louhajang", NameBn = "লৌহজং" },
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Sirajdikhan", NameBn = "সিরাজদিখান" },
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Tongibari", NameBn = "টংগীবাড়ি" },

            // Tangail District
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Tangail Sadar", NameBn = "টাঙ্গাইল সদর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Delduar", NameBn = "দেলদুয়ার" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Basail", NameBn = "বাসাইল" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Bhuanpur", NameBn = "ভূঞাপুর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Dhanbari", NameBn = "ধনবাড়ী" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Ghatail", NameBn = "ঘাটাইল" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Gopalpur", NameBn = "গোপালপুর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Kalihati", NameBn = "কালিহাতী" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Madhupur", NameBn = "মধুপুর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Mirzapur", NameBn = "মির্জাপুর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Nagarpur", NameBn = "নাগরপুর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Sakhipur", NameBn = "সখিপুর" },

            // Kishoreganj District
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Kishoreganj Sadar", NameBn = "কিশোরগঞ্জ সদর" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Hossainpur", NameBn = "হোসেনপুর" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Austagram", NameBn = "অষ্টগ্রাম" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Bajitpur", NameBn = "বাজিতপুর" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Bhairab", NameBn = "ভৈরব" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Itna", NameBn = "ইটনা" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Karimganj", NameBn = "করিমগঞ্জ" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Katiadi", NameBn = "কটিয়াদী" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Kuliarchar", NameBn = "কুলিয়ারচর" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Mithamain", NameBn = "মিঠামইন" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Nikli", NameBn = "নিকলী" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Pakundia", NameBn = "পাকুন্দিয়া" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Tarail", NameBn = "তাড়াইল" },

            // Faridpur District
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Faridpur Sadar", NameBn = "ফরিদপুর সদর" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Boalmari", NameBn = "বোয়ালমারী" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Alfadanga", NameBn = "আলফাডাঙ্গা" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Bhanga", NameBn = "ভাঙ্গা" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Char Bhadrasan", NameBn = "চরভদ্রাসন" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Madhukhali", NameBn = "মধুখালী" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Nagarkanda", NameBn = "নগরকান্দা" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Sadarpur", NameBn = "সদরপুর" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Saltha", NameBn = "সালথা" },

            // Gopalganj District
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Gopalganj Sadar", NameBn = "গোপালগঞ্জ সদর" },
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Kotalipara", NameBn = "কোটালিপাড়া" },
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Kashiani", NameBn = "কাশিয়ানী" },
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Muksudpur", NameBn = "মুকসুদপুর" },
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Tungipara", NameBn = "টুংগীপাড়া" },

            // Madaripur District
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Madaripur Sadar", NameBn = "মাদারীপুর সদর" },
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Shibchar", NameBn = "শিবচর" },
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Dasar", NameBn = "ডাসার" },
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Kalkini", NameBn = "কালকিনি" },
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Rajoir", NameBn = "রাজৈর" },

            // Rajbari District
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Rajbari Sadar", NameBn = "রাজবাড়ী সদর" },
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Baliakandi", NameBn = "বালিয়াকান্দি" },
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Goalanda", NameBn = "গোয়ালন্দ" },
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Kalukhali", NameBn = "কালুখালী" },
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Pangsha", NameBn = "পাংশা" },

            // Narsingdi District
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Narsingdi Sadar", NameBn = "নরসিংদী সদর" },
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Palash", NameBn = "পলাশ" },
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Belabo", NameBn = "বেলাবো" },
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Manohardi", NameBn = "মনোহরদী" },
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Raipura", NameBn = "রায়পুরা" },
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Shibpur", NameBn = "শিবপুর" },

            // Shariatpur District
            new() { Id = new Guid("aa000064-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Shariatpur").Id, Name = "Bhedarganj", NameBn = "ভেদরগঞ্জ" },
            new() { Id = new Guid("aa000064-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Shariatpur").Id, Name = "Damudya", NameBn = "ডামুড্যা" },
            new() { Id = new Guid("aa000064-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Shariatpur").Id, Name = "Gosairhat", NameBn = "গোসাইরহাট" },
            new() { Id = new Guid("aa000064-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Shariatpur").Id, Name = "Naria", NameBn = "নড়িয়া" },
            new() { Id = new Guid("aa000064-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Shariatpur").Id, Name = "Shariatpur Sadar", NameBn = "শরিয়তপুর সদর" },
            new() { Id = new Guid("aa000064-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Shariatpur").Id, Name = "Zajira", NameBn = "জাজিরা" },

            // Chattogram District
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Chattogram Sadar", NameBn = "চট্টগ্রাম সদর" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Pahartali", NameBn = "পাহাড়তলী" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Sitakunda", NameBn = "সীতাকুণ্ড" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Mirsharai", NameBn = "মীরসরাই" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Anwara", NameBn = "আনোয়ারা" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Banshkhali", NameBn = "বাঁশখালী" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Boalkhali", NameBn = "বোয়ালখালী" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Chandanaish", NameBn = "চন্দনাইশ" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Fatikchhari", NameBn = "ফটিকছড়ি" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Hathazari", NameBn = "হাটহাজারী" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Karnaphuli", NameBn = "কর্ণফুলী" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Lohagara", NameBn = "লোহাগড়া" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Patiya", NameBn = "পটিয়া" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000014"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Rangunia", NameBn = "রাঙ্গুনিয়া" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000015"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Raozan", NameBn = "রাউজান" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000016"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Sandwip", NameBn = "সন্দ্বীপ" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000017"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Satkania", NameBn = "সাতকানিয়া" },

            // Cox's Bazar District
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Cox's Bazar Sadar", NameBn = "কক্সবাজার সদর" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Teknaf", NameBn = "টেকনাফ" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Ukhia", NameBn = "উখিয়া" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Chakaria", NameBn = "চকরিয়া" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Eidgaon", NameBn = "ঈদগাঁও" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Kutubdia", NameBn = "কুতুবদিয়া" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Maheshkhali", NameBn = "মহেশখালী" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Pekua", NameBn = "পেকুয়া" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Ramu", NameBn = "রামু" },

            // Comilla District
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Comilla Sadar", NameBn = "কুমিল্লা সদর" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Daudkandi", NameBn = "দাউদকান্দি" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Chandina", NameBn = "চান্দিনা" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Adarsha Sadar", NameBn = "আদর্শ সদর" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Barura", NameBn = "বরুড়া" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Brahmanpara", NameBn = "ব্রাহ্মণপাড়া" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Burichang", NameBn = "বুড়িচং" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Chauddagram", NameBn = "চৌদ্দগ্রাম" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Debidwar", NameBn = "দেবিদ্বার" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Homna", NameBn = "হোমনা" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Laksam", NameBn = "লাকসাম" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Lalmai", NameBn = "লালমাই" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Manoharganj", NameBn = "মনোহরগঞ্জ" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000014"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Meghna", NameBn = "মেঘনা" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000015"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Muradnagar", NameBn = "মুরাদনগর" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000016"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Nangalkot", NameBn = "নাঙ্গলকোট" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000017"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Sadar Dakkhin", NameBn = "সদর দক্ষিণ" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000018"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Titas", NameBn = "তিতাস" },

            // Brahmanbaria District
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Brahmanbaria Sadar", NameBn = "ব্রাহ্মণবাড়িয়া সদর" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Ashuganj", NameBn = "আশুগঞ্জ" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Akhaura", NameBn = "আখাউড়া" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Banchharampur", NameBn = "বাঞ্ছারামপুর" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Bijoynagar", NameBn = "বিজয়নগর" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Kasba", NameBn = "কসবা" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Nabinagar", NameBn = "নবীনগর" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Nasirnagar", NameBn = "নাসিরনগর" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Sarail", NameBn = "সরাইল" },

            // Chandpur District
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Chandpur Sadar", NameBn = "চাঁদপুর সদর" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Faridganj", NameBn = "ফরিদগঞ্জ" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Haimchar", NameBn = "হাইমচর" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Hajiganj", NameBn = "হাজীগঞ্জ" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Kachua", NameBn = "কচুয়া" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Matlab Dakkhin", NameBn = "মতলব দক্ষিণ" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Matlab Uttar", NameBn = "মতলব উত্তর" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Shahrasti", NameBn = "শাহরাস্তি" },

            // Lakshmipur District
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Lakshmipur Sadar", NameBn = "লক্ষ্মীপুর সদর" },
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Raipur", NameBn = "রায়পুর" },
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Kamalnagar", NameBn = "কমলনগর" },
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Ramganj", NameBn = "রামগঞ্জ" },
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Ramgati", NameBn = "রামগতি" },

            // Noakhali District
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Noakhali Sadar", NameBn = "নোয়াখালী সদর" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Sonaimuri", NameBn = "সোনাইমুরী" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Begumganj", NameBn = "বেগমগঞ্জ" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Chatkhil", NameBn = "চাটখিল" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Companiganj", NameBn = "কোম্পানীগঞ্জ" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Hatiya", NameBn = "হাতিয়া" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Kabirhat", NameBn = "কবিরহাট" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Senbag", NameBn = "সেনবাগ" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Subarnachar", NameBn = "সুবর্ণচর" },

            // Feni District
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Feni Sadar", NameBn = "ফেনী সদর" },
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Daganbhuiyan", NameBn = "দাগনভূঁইয়া" },
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Chhagalnaiya", NameBn = "ছাগলনাইয়া" },
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Fulgazi", NameBn = "ফুলগাজী" },
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Parashuram", NameBn = "পরশুরাম" },
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Sonagazi", NameBn = "সোনাগাজী" },

            // Khagrachhari District
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Khagrachhari Sadar", NameBn = "খাগড়াছড়ি সদর" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Mahalchhari", NameBn = "মহালছড়ি" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Dighinala", NameBn = "দিঘীনালা" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Guimara", NameBn = "গুইমারা" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Lakkhichhari", NameBn = "লক্ষ্মীছড়ি" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Manikchhari", NameBn = "ফটিকছড়ি" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Matiranga", NameBn = "মাটিরাঙ্গা" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Panchhari", NameBn = "পানছড়ি" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Ramgarh", NameBn = "রামগড়" },

            // Rangamati District
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Rangamati Sadar", NameBn = "রাঙ্গামাটি সদর" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Kaptai", NameBn = "কাপ্তাই" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Baghaichhari", NameBn = "বাঘাইছড়ি" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Barkal", NameBn = "বরকল" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Belaichhari", NameBn = "বিলাইছড়ি" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Jurachhari", NameBn = "জুরাছড়ি" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Kawkhali", NameBn = "কাউখালী" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Langadu", NameBn = "লংগদু" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Naniarchar", NameBn = "নানিয়ারচর" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Rajasthali", NameBn = "রাজস্থলী" },

            // Bandarban District
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Bandarban Sadar", NameBn = "বান্দরবান সদর" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Ali Kadam", NameBn = "আলীকদম" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Lama", NameBn = "লামা" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Naikkhongchhari", NameBn = "নাইক্ষ্যংছড়ি" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Rowangchhari", NameBn = "রোয়াংছড়ি" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Ruma", NameBn = "রুমা" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Thanchi", NameBn = "থানচি" },

            // Rajshahi District
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Rajshahi Sadar", NameBn = "রাজশাহী সদর" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Godagari", NameBn = "গোদাগারী" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Bagha", NameBn = "বাঘা" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Bagmara", NameBn = "বাগমারা" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Charghat", NameBn = "চারঘাট" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Durgapur", NameBn = "দুর্গাপুর" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Mohanpur", NameBn = "লালমোহন" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Paba", NameBn = "পবা" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Puthia", NameBn = "পুঠিয়া" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Tanore", NameBn = "তানোর" },

            // Natore District
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Natore Sadar", NameBn = "নাটোর সদর" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Baraigram", NameBn = "বড়াইগ্রাম" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Bagatipara", NameBn = "বাগাতিপাড়া" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Gurudaspur", NameBn = "গুরুদাসপুর" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Lalpur", NameBn = "লালপুর" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Naldanga", NameBn = "নলডাঙ্গা" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Singra", NameBn = "সিংড়া" },

            // Bogura District
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Bogura Sadar", NameBn = "বগুড়া সদর" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Shibganj", NameBn = "শিবগঞ্জ" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Adamdighi", NameBn = "আদমদিঘি" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Dhunat", NameBn = "ধুনট" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Dupchachia", NameBn = "দুপচাঁচিয়া" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Gabtali", NameBn = "গাবতলী" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Kahaloo", NameBn = "কাহালু" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Nandigram", NameBn = "নন্দিগ্রাম" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Sariakandi", NameBn = "সারিয়াকান্দি" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Shajahanpur", NameBn = "শাজাহানপুর" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Sherpur", NameBn = "শেরপুর" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Sonatala", NameBn = "সোনাতলা" },

            // Chapainawabganj District
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Chapainawabganj Sadar", NameBn = "চাঁপাইনবাবগঞ্জ সদর" },
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Rohanpur", NameBn = "রহনপুর" },
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Bholahat", NameBn = "ভোলাহাট" },
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Gomastapur", NameBn = "গোমস্তাপুর" },
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Nachole", NameBn = "নাচোল" },
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Shibganj", NameBn = "শিবগঞ্জ" },

            // Naogaon District
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Naogaon Sadar", NameBn = "নওগাঁ সদর" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Atrai", NameBn = "আত্রাই" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Badalgachhi", NameBn = "বদলগাছী" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Dhamoirhat", NameBn = "ধামইরহাট" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Mahadebpur", NameBn = "মহাদেবপুর" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Manda", NameBn = "মান্দা" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Niamatpur", NameBn = "নিয়ামতপুর" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Patnitala", NameBn = "পত্নিতলা" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Porsha", NameBn = "পোরশা" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Raninagar", NameBn = "রাণীনগর" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Sapahar", NameBn = "সাপাহার" },

            // Sirajganj District
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Sirajganj Sadar", NameBn = "সিরাজগঞ্জ সদর" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Raiganj", NameBn = "রায়গঞ্জ" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Belkuchi", NameBn = "বেলকুচি" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Chouhali", NameBn = "চৌহালি" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Kamarkhanda", NameBn = "কামারখন্দ" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Kazipur", NameBn = "কাজীপুর" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Rayganj", NameBn = "রায়গঞ্জ" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Shahjadpur", NameBn = "শাহজাদপুর" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Tarash", NameBn = "তাড়াশ" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Ullapara", NameBn = "উল্লাপাড়া" },

            // Pabna District
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Pabna Sadar", NameBn = "পাবনা সদর" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Atgharia", NameBn = "আটঘরিয়া" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Bera", NameBn = "বেড়া" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Bhangura", NameBn = "ভাঙ্গুড়া" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Chatmohar", NameBn = "চাটমোহর" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Faridpur", NameBn = "ফরিদপুর" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Ishwardi", NameBn = "ঈশ্বরদী" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Santhia", NameBn = "সাঁথিয়া" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Sujanagar", NameBn = "সুজানগর" },

            // Joypurhat District
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Joypurhat Sadar", NameBn = "জয়পুরহাট সদর" },
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Akkelpur", NameBn = "আক্কেলপুর" },
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Kalai", NameBn = "কালাই" },
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Khetlal", NameBn = "ক্ষেতলাল" },
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Panchbibi", NameBn = "পাঁচবিবি" },

            // Khulna District
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Khulna Sadar", NameBn = "খুলনা সদর" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Terokhada", NameBn = "তেরখাদা" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Batiaghata", NameBn = "বটিয়াঘাটা" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Dacope", NameBn = "দাকোপ" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Dighalia", NameBn = "কাঠালিয়া" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Dumuria", NameBn = "ডুমুরিয়া" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Koyra", NameBn = "কয়রা" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Paikgachha", NameBn = "চৌগাছা" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Phultala", NameBn = "ফুলতলা" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Rupsa", NameBn = "রূপসা" },

            // Satkhira District
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Satkhira Sadar", NameBn = "সাতক্ষীরা সদর" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Assasuni", NameBn = "আসসানি" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Debhata", NameBn = "দেবহাটা" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Kalaroa", NameBn = "কলারোয়া" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Kaliganj", NameBn = "কালীগঞ্জ" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Shyamnagar", NameBn = "শ্যামনগর" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Tala", NameBn = "তালা" },

            // Jessore District
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Jessore Sadar", NameBn = "যশোর সদর" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Jhikargacha", NameBn = "ঝিকারগাছা" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Abhaynagar", NameBn = "অভয়নগর" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Bagharpara", NameBn = "বাঘারপাড়া" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Chaugachha", NameBn = "চৌগাছা" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Keshabpur", NameBn = "কেশবপুর" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Manirampur", NameBn = "মণিরামপুর" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Sharsha", NameBn = "শার্শা" },

            // Bagerhat District
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Bagerhat Sadar", NameBn = "বাগেরহাট সদর" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Mongla", NameBn = "মোংলা" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Chitalmari", NameBn = "চিতলমারী" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Fakirhat", NameBn = "ফকিরহাট" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Kachua", NameBn = "কচুয়া" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Mollahat", NameBn = "মোল্লাহাট" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Morelganj", NameBn = "মোড়েলগঞ্জ" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Rampal", NameBn = "রামপাল" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Sharankhola", NameBn = "শরণখোলা" },

            // Jhenaidah District
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Jhenaidah Sadar", NameBn = "ঝিনাইদহ সদর" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Shakhipur", NameBn = "শাখিপুর" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Harinakundu", NameBn = "হরিণাকুন্ডু" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Kaliganj", NameBn = "কালীগঞ্জ" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Kotchandpur", NameBn = "কোটচাঁদপুর" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Maheshpur", NameBn = "মহেশপুর" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Shailkupa", NameBn = "শৈলকুপা" },

            // Magura District
            new() { Id = new Guid("aa000037-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Magura").Id, Name = "Magura Sadar", NameBn = "মাগুরা সদর" },
            new() { Id = new Guid("aa000037-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Magura").Id, Name = "Shalikha", NameBn = "শালিখা" },
            new() { Id = new Guid("aa000037-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Magura").Id, Name = "Mohammadpur", NameBn = "মহম্মদপুর" },
            new() { Id = new Guid("aa000037-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Magura").Id, Name = "Sreepur", NameBn = "শ্রীপুর" },

            // Narail District
            new() { Id = new Guid("aa000038-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Narail").Id, Name = "Narail Sadar", NameBn = "নড়াইল সদর" },
            new() { Id = new Guid("aa000038-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Narail").Id, Name = "Lohagara", NameBn = "লোহাগাড়া" },
            new() { Id = new Guid("aa000038-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Narail").Id, Name = "Kalia", NameBn = "কালিয়া" },

            // Kushtia District
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Kushtia Sadar", NameBn = "কুষ্টিয়া সদর" },
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Kumarkhali", NameBn = "কুমারখালী" },
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Bheramara", NameBn = "ভেড়ামারা" },
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Daulatpur", NameBn = "দৌলতপুর" },
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Khoksa", NameBn = "খোকসা" },
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Mirpur", NameBn = "মিরপুর" },

            // Meherpur District
            new() { Id = new Guid("aa000040-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Meherpur").Id, Name = "Meherpur Sadar", NameBn = "মেহেরপুর সদর" },
            new() { Id = new Guid("aa000040-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Meherpur").Id, Name = "Gangni", NameBn = "গাংনী" },
            new() { Id = new Guid("aa000040-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Meherpur").Id, Name = "Mujibnagar", NameBn = "মুজিবনগর" },

            // Chuadanga District
            new() { Id = new Guid("aa000041-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chuadanga").Id, Name = "Chuadanga Sadar", NameBn = "চুয়াডাঙ্গা সদর" },
            new() { Id = new Guid("aa000041-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chuadanga").Id, Name = "Alamdanga", NameBn = "আলমডাঙ্গা" },
            new() { Id = new Guid("aa000041-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Chuadanga").Id, Name = "Damurhuda", NameBn = "দামুড়হুদা" },
            new() { Id = new Guid("aa000041-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Chuadanga").Id, Name = "Jibannagar", NameBn = "জীবননগর" },

            // Barishal District
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Barishal Sadar", NameBn = "বরিশাল সদর" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Bakerganj", NameBn = "বাকেরগঞ্জ" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Agailjhara", NameBn = "আগৈলঝাড়া" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Babuganj", NameBn = "বাবুগঞ্জ" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Banaripara", NameBn = "বানারীপাড়া" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Gaurnadi", NameBn = "গৌরনদী" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Hijla", NameBn = "হিজলা" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Mehendiganj", NameBn = "মেহেন্দিগঞ্জ" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Muladi", NameBn = "মুলাদী" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Ujirpur", NameBn = "মিরপুর" },

            // Patuakhali District
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Patuakhali Sadar", NameBn = "পটুয়াখালী সদর" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Dumki", NameBn = "দুমকি" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Bauphal", NameBn = "বাউফল" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Dashmina", NameBn = "দশমিনা" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Galachipa", NameBn = "গলাচিপা" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Kalapara", NameBn = "কলাপাড়া" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Mirzaganj", NameBn = "মির্জাগঞ্জ" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Rangabali", NameBn = "রাঙ্গাবালী" },

            // Bhola District
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Bhola Sadar", NameBn = "ভোলা সদর" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Burhanuddin", NameBn = "বুরহানউদ্দিন" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Charfasson", NameBn = "চরফ্যাশন" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Daulatkhan", NameBn = "দৌলতখান" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Lalmohan", NameBn = "লালমোহন" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Monpura", NameBn = "মনপুরা" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Tazumuddin", NameBn = "তজুমদ্দিন" },

            // Pirojpur District
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Pirojpur Sadar", NameBn = "পিরোজপুর সদর" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Mathbaria", NameBn = "মাঠবাড়িয়া" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Bhandaria", NameBn = "ভান্ডারিয়া" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Indurkani", NameBn = "ইন্দুরকানী" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Kawkhali", NameBn = "কাউখালী" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Nazirpur", NameBn = "নাজিরপুর" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Nesarabad (Swarupkathi)", NameBn = "নেছারাবাদ (স্বরূপকাঠি)" },

            // Jhalakathi District
            new() { Id = new Guid("aa000046-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jhalakathi").Id, Name = "Jhalakathi Sadar", NameBn = "ঝালকাঠি সদর" },
            new() { Id = new Guid("aa000046-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jhalakathi").Id, Name = "Nalchity", NameBn = "নালচিত্য" },
            new() { Id = new Guid("aa000046-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Jhalakathi").Id, Name = "Kanthalia", NameBn = "কাঠালিয়া" },
            new() { Id = new Guid("aa000046-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Jhalakathi").Id, Name = "Rajapur", NameBn = "রাজাপুর" },

            // Barguna District
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Barguna Sadar", NameBn = "বরগুনা সদর" },
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Amtali", NameBn = "আমতলী" },
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Bamna", NameBn = "বামনা" },
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Betagi", NameBn = "বেতাগী" },
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Patharghata", NameBn = "চারঘাট" },
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Taltali", NameBn = "তালতলি" },

            // Sylhet District
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Sylhet Sadar", NameBn = "সিলেট সদর" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Beanibazar", NameBn = "বিয়ানীবাজার" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Zakiganj", NameBn = "জকিগঞ্জ" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Balaganj", NameBn = "বালাগঞ্জ" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Bishwanath", NameBn = "বিশ্বনাথ" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Companiganj", NameBn = "কোম্পানীগঞ্জ" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Dakkhin Surma", NameBn = "দক্ষিণ সুরমা" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Fenchuganj", NameBn = "ফেঞ্চুগঞ্জ" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Golapganj", NameBn = "গোলাপগঞ্জ" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Gowainghat", NameBn = "গোয়াইনঘাট" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Jaintapur", NameBn = "জৈন্তাপুর" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Kanaighat", NameBn = "কানাইঘাট" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Osmaninagar", NameBn = "ওসমানী নগর" },

            // Habiganj District
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Habiganj Sadar", NameBn = "হবিগঞ্জ সদর" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Lakhai", NameBn = "লাখাই" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Ajmiriganj", NameBn = "আজমিরীগঞ্জ" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Bahubal", NameBn = "বাহুবল" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Baniachong", NameBn = "বানিয়াচং" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Chunarughat", NameBn = "চুনারুঘাট" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Madhabpur", NameBn = "মাধবপুর" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Nabiganj", NameBn = "নবীগঞ্জ" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Shayestaganj", NameBn = "শায়েস্তাগঞ্জ" },

            // Moulvibazar District
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Moulvibazar Sadar", NameBn = "মৌলভীবাজার সদর" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Barlekha", NameBn = "বড়লেখা" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Juri", NameBn = "জুড়ী" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Kamalganj", NameBn = "জামালগঞ্জ" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Kulaura", NameBn = "কুলাউড়া" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Rajnagar", NameBn = "রাজনগর" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Sreemangal", NameBn = "শ্রীমঙ্গল" },

            // Sunamganj District
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Sunamganj Sadar", NameBn = "সুনামগঞ্জ সদর" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Tahirpur", NameBn = "তাহিরপুর" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Bishwambharpur", NameBn = "বিশ্বম্ভরপুর" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Chhatak", NameBn = "ছাতক" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Derai", NameBn = "দিরাই" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Dharmapasha", NameBn = "ধর্মপাশা" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Dowarabazar", NameBn = "দোয়ারাবাজার" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Jagannathpur", NameBn = "জগন্নাথপুর" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Jamalganj", NameBn = "জামালগঞ্জ" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Madhyanagar", NameBn = "মধ্যনগর" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Shalla", NameBn = "শাল্লা" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Shantiganj", NameBn = "শান্তিগঞ্জ" },

            // Rangpur District
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Rangpur Sadar", NameBn = "রংপুর সদর" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Gangachara", NameBn = "গঙ্গাচরা" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Badarganj", NameBn = "মাদারগঞ্জ" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Kaunia", NameBn = "কাউনিয়া" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Mithapukur", NameBn = "মিঠাপুকুর" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Pirgachha", NameBn = "পীরগাছা" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Pirganj", NameBn = "পীরগঞ্জ" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Taraganj", NameBn = "বালাগঞ্জ" },

            // Dinajpur District
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Dinajpur Sadar", NameBn = "দিনাজপুর সদর" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Parbatipur", NameBn = "পার্বতীপুর" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Birampur", NameBn = "বিরামপুর" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Birganj", NameBn = "বীরগঞ্জ" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Birol", NameBn = "বিরল" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Bochaganj", NameBn = "বোচাগঞ্জ" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Chirirbandar", NameBn = "চিরিরবন্দর" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Fulbari", NameBn = "ফুলবাড়ী" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Ghoraghat", NameBn = "ঘোড়াঘাট" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Hakimpur", NameBn = "হাকিমপুর" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Kaharole", NameBn = "কাহারোল" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Khansama", NameBn = "খানসামা" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Nababganj", NameBn = "নবাবগঞ্জ" },

            // Thakurgaon District
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Thakurgaon Sadar", NameBn = "ঠাকুরগাঁও সদর" },
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Pirganj", NameBn = "পীরগঞ্জ" },
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Baliadangi", NameBn = "বালিয়াডাঙ্গী" },
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Haripur", NameBn = "হরিপুর" },
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Ranishankail", NameBn = "রাণীশংকৈল" },

            // Kurigram District
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Kurigram Sadar", NameBn = "কুড়িগ্রাম সদর" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Nageshwari", NameBn = "নাগেশ্বরী" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Bhurungamari", NameBn = "ভুরুঙ্গামারী" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Chilmari", NameBn = "চিলমারী" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Phulbari", NameBn = "ফুলবাড়ী" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Rajarhat", NameBn = "রাজারহাট" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Rajibpur", NameBn = "চর রাজিবপুর" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Roumari", NameBn = "রৌমারী" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Ulipur", NameBn = "উলিপুর" },

            // Gaibandha District
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Gaibandha Sadar", NameBn = "গাইবান্ধা সদর" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Sundarganj", NameBn = "সুন্দরগঞ্জ" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Fulchhari", NameBn = "ফুলছড়ি" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Gobindaganj", NameBn = "গোবিন্দগঞ্জ" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Palashbari", NameBn = "পলাশবাড়ী" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Sadullapur", NameBn = "সাদুল্লাপুর" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Saghata", NameBn = "সাঘাটা" },

            // Lalmonirhat District
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Lalmonirhat Sadar", NameBn = "লালমনিরহাট সদর" },
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Aditmari", NameBn = "আদিতমারী" },
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Hatibandha", NameBn = "হাতীবান্ধা" },
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Kaliganj", NameBn = "কালীগঞ্জ" },
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Patgram", NameBn = "পাটগ্রাম" },

            // Nilphamari District
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Nilphamari Sadar", NameBn = "নীলফামারী সদর" },
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Saidpur", NameBn = "সৈদপুর" },
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Dimla", NameBn = "ডিমলা" },
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Domar", NameBn = "ডোমার" },
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Jaldhaka", NameBn = "জলঢাকা" },
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Kishoreganj", NameBn = "কিশোরগঞ্জ সদর" },

            // Panchagarh District
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Panchagarh Sadar", NameBn = "পঞ্চগড় সদর" },
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Tetulia", NameBn = "তেতুলিয়া" },
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Atowari", NameBn = "আটোয়ারী" },
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Boda", NameBn = "বোদা" },
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Debiganj", NameBn = "দেবীগঞ্জ" },

            // Mymensingh District
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Mymensingh Sadar", NameBn = "ময়মনসিংহ সদর" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Trishal", NameBn = "ত্রিশাল" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Bhaluka", NameBn = "ভালুকা" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Dhobaura", NameBn = "ধোবাউড়া" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Fulbaria", NameBn = "ফুলবাড়ীয়া" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Fulpur", NameBn = "ফুলপুর" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Gafargaon", NameBn = "গফরগাঁও" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Gouripur", NameBn = "গৌরীপুর" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Haluaghat", NameBn = "হালুয়াঘাট" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Ishwarganj", NameBn = "ঈশ্বরগঞ্জ" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Muktagachha", NameBn = "মুক্তাগাছা" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000012"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Nandail", NameBn = "নান্দাইল" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000013"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Tarakanda", NameBn = "তারাকান্দা" },

            // Jamalpur District
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Jamalpur Sadar", NameBn = "জামালপুর সদর" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Melandaha", NameBn = "মেলান্দহ" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Bakshiganj", NameBn = "বকশীগঞ্জ" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Dewanganj", NameBn = "দেওয়ানগঞ্জ" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Islampur", NameBn = "ইসলামপুর" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Madarganj", NameBn = "মাদারগঞ্জ" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Sarishabari", NameBn = "সরিষাবাড়ী" },

            // Sherpur District
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Sherpur Sadar", NameBn = "শেরপুর সদর" },
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Nalitabari", NameBn = "নালিতাবাড়ী" },
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Jhenaigati", NameBn = "ঝিনাইগাতী" },
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Nakla", NameBn = "নকলা" },
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Sreebardi", NameBn = "শ্রীবরদী" },

            // Netrokona District
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Netrokona Sadar", NameBn = "নেত্রকোণা সদর" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Kalmakanda", NameBn = "কালমাকান্দা" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Atpara", NameBn = "আটপাড়া" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Barhatta", NameBn = "বারহাট্টা" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Durgapur", NameBn = "দুর্গাপুর" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Kendua", NameBn = "কেন্দুয়া" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000007"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Khaliajuri", NameBn = "খালিয়াজুরী" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000008"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Madan", NameBn = "মদন" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000009"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Mohanganj", NameBn = "মোহনগঞ্জ" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000010"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Netrakona Sadar", NameBn = "নেত্রকোণা সদর" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000011"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Purbadhala", NameBn = "পূর্বধলা" },
        };
        foreach (var u in list) { u.CreatedAt = SeedTimestamp; u.UpdatedAt = null; }
        return list;
    }
}