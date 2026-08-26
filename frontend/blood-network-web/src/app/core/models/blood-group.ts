export enum BloodGroup {
  APositive = 'APositive',
  ANegative = 'ANegative',
  BPositive = 'BPositive',
  BNegative = 'BNegative',
  ABPositive = 'ABPositive',
  ABNegative = 'ABNegative',
  OPositive = 'OPositive',
  ONegative = 'ONegative'
}

export const BloodGroupLabels: Record<BloodGroup, string> = {
  [BloodGroup.APositive]: 'A+',
  [BloodGroup.ANegative]: 'A-',
  [BloodGroup.BPositive]: 'B+',
  [BloodGroup.BNegative]: 'B-',
  [BloodGroup.ABPositive]: 'AB+',
  [BloodGroup.ABNegative]: 'AB-',
  [BloodGroup.OPositive]: 'O+',
  [BloodGroup.ONegative]: 'O-'
};
