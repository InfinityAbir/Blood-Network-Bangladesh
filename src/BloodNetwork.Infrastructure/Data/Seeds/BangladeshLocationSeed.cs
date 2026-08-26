using BloodNetwork.Domain.Entities;

namespace BloodNetwork.Infrastructure.Data.Seeds;

public static class BangladeshLocationSeed
{
    public static List<Division> GetDivisions()
    {
        return new List<Division>
        {
            new() { Id = new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), Name = "Dhaka", NameBn = "ঢাকা" },
            new() { Id = new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), Name = "Chattogram", NameBn = "চট্টগ্রাম" },
            new() { Id = new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), Name = "Rajshahi", NameBn = "রাজশাহী" },
            new() { Id = new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), Name = "Khulna", NameBn = "খুলনা" },
            new() { Id = new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), Name = "Barishal", NameBn = "বরিশাল" },
            new() { Id = new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), Name = "Sylhet", NameBn = "সিলেট" },
            new() { Id = new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), Name = "Rangpur", NameBn = "রংপুর" },
            new() { Id = new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), Name = "Mymensingh", NameBn = "ময়মনসিংহ" }
        };
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

        return new List<District>
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
            new() { Id = new Guid("88888888-8888-4888-8888-888888888804"), DivisionId = mymensinghId, Name = "Netrokona", NameBn = "নেত্রকোণা" }
        };
    }

    public static List<Upazila> GetUpazilas()
    {
        var districts = GetDistricts();

        return new List<Upazila>
        {
            // Dhaka District
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Dhanmondi", NameBn = "ধানমন্ডি" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Gulshan", NameBn = "গুলশান" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Mirpur", NameBn = "মিরপুর" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Uttara", NameBn = "উত্তরা" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000005"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Mohammadpur", NameBn = "মোহাম্মদপুর" },
            new() { Id = new Guid("aa000001-0000-4000-8000-000000000006"), DistrictId = districts.First(d => d.Name == "Dhaka").Id, Name = "Savar", NameBn = "সাভার" },

            // Gazipur District
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Gazipur Sadar", NameBn = "গাজীপুর সদর" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Tongi", NameBn = "টঙ্গী" },
            new() { Id = new Guid("aa000002-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Gazipur").Id, Name = "Kaliakair", NameBn = "কালিয়াইর" },

            // Narayanganj District
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Narayanganj Sadar", NameBn = "নারায়ণগঞ্জ সদর" },
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Sonargaon", NameBn = "সোনারগাঁও" },
            new() { Id = new Guid("aa000003-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Narayanganj").Id, Name = "Bandar", NameBn = "বন্দর" },

            // Manikganj District
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Manikganj Sadar", NameBn = "মানিকগঞ্জ সদর" },
            new() { Id = new Guid("aa000004-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Manikganj").Id, Name = "Singair", NameBn = "সিঙ্গাইর" },

            // Munshiganj District
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Munshiganj Sadar", NameBn = "মুন্সিগঞ্জ সদর" },
            new() { Id = new Guid("aa000005-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Munshiganj").Id, Name = "Sreenagar", NameBn = "শ্রীনগর" },

            // Tangail District
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Tangail Sadar", NameBn = "টাঙ্গাইল সদর" },
            new() { Id = new Guid("aa000006-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Tangail").Id, Name = "Delduar", NameBn = "দেলদুয়ার" },

            // Kishoreganj District
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Kishoreganj Sadar", NameBn = "কিশোরগঞ্জ সদর" },
            new() { Id = new Guid("aa000007-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Kishoreganj").Id, Name = "Hossainpur", NameBn = "হোসেনপুর" },

            // Faridpur District
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Faridpur Sadar", NameBn = "ফরিদপুর সদর" },
            new() { Id = new Guid("aa000008-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Faridpur").Id, Name = "Boalmari", NameBn = "বোয়ালমারী" },

            // Gopalganj District
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Gopalganj Sadar", NameBn = "গোপালগঞ্জ সদর" },
            new() { Id = new Guid("aa000009-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Gopalganj").Id, Name = "Kotalipara", NameBn = "কোটালিপাড়া" },

            // Madaripur District
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Madaripur Sadar", NameBn = "মাদারীপুর সদর" },
            new() { Id = new Guid("aa000010-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Madaripur").Id, Name = "Shibchar", NameBn = "শিবচর" },

            // Rajbari District
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Rajbari Sadar", NameBn = "রাজবাড়ী সদর" },
            new() { Id = new Guid("aa000011-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rajbari").Id, Name = "Baliakandi", NameBn = "বালিয়াকান্দি" },

            // Narsingdi District
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Narsingdi Sadar", NameBn = "নরসিংদী সদর" },
            new() { Id = new Guid("aa000012-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Narsingdi").Id, Name = "Palash", NameBn = "পলাশ" },

            // Chattogram District
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Chattogram Sadar", NameBn = "চট্টগ্রাম সদর" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Pahartali", NameBn = "পাহাড়তলী" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Sitakunda", NameBn = "সীতাকুণ্ড" },
            new() { Id = new Guid("aa000013-0000-4000-8000-000000000004"), DistrictId = districts.First(d => d.Name == "Chattogram").Id, Name = "Mirsharai", NameBn = "মীরসরাই" },

            // Cox's Bazar District
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Cox's Bazar Sadar", NameBn = "কক্সবাজার সদর" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Teknaf", NameBn = "টেকনাফ" },
            new() { Id = new Guid("aa000014-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Cox's Bazar").Id, Name = "Ukhia", NameBn = "উখিয়া" },

            // Comilla District
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Comilla Sadar", NameBn = "কুমিল্লা সদর" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Daudkandi", NameBn = "দাউদকান্দি" },
            new() { Id = new Guid("aa000015-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Comilla").Id, Name = "Chandina", NameBn = "চান্দিনা" },

            // Brahmanbaria District
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Brahmanbaria Sadar", NameBn = "ব্রাহ্মণবাড়িয়া সদর" },
            new() { Id = new Guid("aa000016-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Brahmanbaria").Id, Name = "Ashuganj", NameBn = "আশুগঞ্জ" },

            // Chandpur District
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Chandpur Sadar", NameBn = "চাঁদপুর সদর" },
            new() { Id = new Guid("aa000017-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chandpur").Id, Name = "Faridganj", NameBn = "ফরিদগঞ্জ" },

            // Lakshmipur District
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Lakshmipur Sadar", NameBn = "লক্ষ্মীপুর সদর" },
            new() { Id = new Guid("aa000018-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Lakshmipur").Id, Name = "Raipur", NameBn = "রায়পুর" },

            // Noakhali District
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Noakhali Sadar", NameBn = "নোয়াখালী সদর" },
            new() { Id = new Guid("aa000019-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Noakhali").Id, Name = "Sonaimuri", NameBn = "সোনাইমুরী" },

            // Feni District
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Feni Sadar", NameBn = "ফেনী সদর" },
            new() { Id = new Guid("aa000020-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Feni").Id, Name = "Daganbhuiyan", NameBn = "দাগনভূঁইয়া" },

            // Khagrachhari District
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Khagrachhari Sadar", NameBn = "খাগড়াছড়ি সদর" },
            new() { Id = new Guid("aa000021-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Khagrachhari").Id, Name = "Mahalchhari", NameBn = "মহালছড়ি" },

            // Rangamati District
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Rangamati Sadar", NameBn = "রাঙ্গামাটি সদর" },
            new() { Id = new Guid("aa000022-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rangamati").Id, Name = "Kaptai", NameBn = "কাপ্তাই" },

            // Bandarban District
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Bandarban Sadar", NameBn = "বান্দরবান সদর" },
            new() { Id = new Guid("aa000023-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bandarban").Id, Name = "Ali Kadam", NameBn = "আলীকদম" },

            // Rajshahi District
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Rajshahi Sadar", NameBn = "রাজশাহী সদর" },
            new() { Id = new Guid("aa000024-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rajshahi").Id, Name = "Godagari", NameBn = "গোদাগারী" },

            // Natore District
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Natore Sadar", NameBn = "নাটোর সদর" },
            new() { Id = new Guid("aa000025-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Natore").Id, Name = "Baraigram", NameBn = "বড়াইগ্রাম" },

            // Bogura District
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Bogura Sadar", NameBn = "বগুড়া সদর" },
            new() { Id = new Guid("aa000026-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bogura").Id, Name = "Shibganj", NameBn = "শিবগঞ্জ" },

            // Chapainawabganj District
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Chapainawabganj Sadar", NameBn = "চাঁপাইনবাবগঞ্জ সদর" },
            new() { Id = new Guid("aa000027-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chapainawabganj").Id, Name = "Rohanpur", NameBn = "রহনপুর" },

            // Naogaon District
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Naogaon Sadar", NameBn = "নওগাঁ সদর" },
            new() { Id = new Guid("aa000028-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Naogaon").Id, Name = "Atrai", NameBn = "আত্রাই" },

            // Sirajganj District
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Sirajganj Sadar", NameBn = "সিরাজগঞ্জ সদর" },
            new() { Id = new Guid("aa000029-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sirajganj").Id, Name = "Raiganj", NameBn = "রায়গঞ্জ" },

            // Pabna District
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Pabna Sadar", NameBn = "পাবনা সদর" },
            new() { Id = new Guid("aa000030-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Pabna").Id, Name = "Atgharia", NameBn = "আটঘরিয়া" },

            // Joypurhat District
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Joypurhat Sadar", NameBn = "জয়পুরহাট সদর" },
            new() { Id = new Guid("aa000031-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Joypurhat").Id, Name = "Akkelpur", NameBn = "আক্কেলপুর" },

            // Khulna District
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Khulna Sadar", NameBn = "খুলনা সদর" },
            new() { Id = new Guid("aa000032-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Khulna").Id, Name = "Terokhada", NameBn = "তেরখাদা" },

            // Satkhira District
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Satkhira Sadar", NameBn = "সাতক্ষীরা সদর" },
            new() { Id = new Guid("aa000033-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Satkhira").Id, Name = "Assasuni", NameBn = "আসসানি" },

            // Jessore District
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Jessore Sadar", NameBn = "যশোর সদর" },
            new() { Id = new Guid("aa000034-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jessore").Id, Name = "Jhikargacha", NameBn = "ঝিকারগাছা" },

            // Bagerhat District
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Bagerhat Sadar", NameBn = "বাগেরহাট সদর" },
            new() { Id = new Guid("aa000035-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bagerhat").Id, Name = "Mongla", NameBn = "মোংলা" },

            // Jhenaidah District
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Jhenaidah Sadar", NameBn = "ঝিনাইদহ সদর" },
            new() { Id = new Guid("aa000036-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jhenaidah").Id, Name = "Shakhipur", NameBn = "শাখিপুর" },

            // Magura District
            new() { Id = new Guid("aa000037-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Magura").Id, Name = "Magura Sadar", NameBn = "মাগুরা সদর" },
            new() { Id = new Guid("aa000037-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Magura").Id, Name = "Shalikha", NameBn = "শালিখা" },

            // Narail District
            new() { Id = new Guid("aa000038-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Narail").Id, Name = "Narail Sadar", NameBn = "নড়াইল সদর" },
            new() { Id = new Guid("aa000038-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Narail").Id, Name = "Lohagara", NameBn = "লোহাগাড়া" },

            // Kushtia District
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Kushtia Sadar", NameBn = "কুষ্টিয়া সদর" },
            new() { Id = new Guid("aa000039-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Kushtia").Id, Name = "Kumarkhali", NameBn = "কুমারখালী" },

            // Meherpur District
            new() { Id = new Guid("aa000040-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Meherpur").Id, Name = "Meherpur Sadar", NameBn = "মেহেরপুর সদর" },
            new() { Id = new Guid("aa000040-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Meherpur").Id, Name = "Gangni", NameBn = "গাংনী" },

            // Chuadanga District
            new() { Id = new Guid("aa000041-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Chuadanga").Id, Name = "Chuadanga Sadar", NameBn = "চুয়াডাঙ্গা সদর" },
            new() { Id = new Guid("aa000041-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Chuadanga").Id, Name = "Alamdanga", NameBn = "আলমডাঙ্গা" },

            // Barishal District
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Barishal Sadar", NameBn = "বরিশাল সদর" },
            new() { Id = new Guid("aa000042-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Barishal").Id, Name = "Bakerganj", NameBn = "বাকেরগঞ্জ" },

            // Patuakhali District
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Patuakhali Sadar", NameBn = "পটুয়াখালী সদর" },
            new() { Id = new Guid("aa000043-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Patuakhali").Id, Name = "Dumki", NameBn = "দুমকি" },

            // Bhola District
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Bhola Sadar", NameBn = "ভোলা সদর" },
            new() { Id = new Guid("aa000044-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Bhola").Id, Name = "Burhanuddin", NameBn = "বুরহানউদ্দিন" },

            // Pirojpur District
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Pirojpur Sadar", NameBn = "পিরোজপুর সদর" },
            new() { Id = new Guid("aa000045-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Pirojpur").Id, Name = "Mathbaria", NameBn = "মাঠবাড়িয়া" },

            // Jhalakathi District
            new() { Id = new Guid("aa000046-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jhalakathi").Id, Name = "Jhalakathi Sadar", NameBn = "ঝালকাঠি সদর" },
            new() { Id = new Guid("aa000046-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jhalakathi").Id, Name = "Nalchity", NameBn = "নালচিত্য" },

            // Barguna District
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Barguna Sadar", NameBn = "বরগুনা সদর" },
            new() { Id = new Guid("aa000047-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Barguna").Id, Name = "Amtali", NameBn = "আমতলী" },

            // Sylhet District
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Sylhet Sadar", NameBn = "সিলেট সদর" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Beanibazar", NameBn = "বিয়ানীবাজার" },
            new() { Id = new Guid("aa000048-0000-4000-8000-000000000003"), DistrictId = districts.First(d => d.Name == "Sylhet").Id, Name = "Zakiganj", NameBn = "জকিগঞ্জ" },

            // Habiganj District
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Habiganj Sadar", NameBn = "হবিগঞ্জ সদর" },
            new() { Id = new Guid("aa000049-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Habiganj").Id, Name = "Lakhai", NameBn = "লাখাই" },

            // Moulvibazar District
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Moulvibazar Sadar", NameBn = "মৌলভীবাজার সদর" },
            new() { Id = new Guid("aa000050-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Moulvibazar").Id, Name = "Barlekha", NameBn = "বড়লেখা" },

            // Sunamganj District
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Sunamganj Sadar", NameBn = "সুনামগঞ্জ সদর" },
            new() { Id = new Guid("aa000051-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sunamganj").Id, Name = "Tahirpur", NameBn = "তাহিরপুর" },

            // Rangpur District
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Rangpur Sadar", NameBn = "রংপুর সদর" },
            new() { Id = new Guid("aa000052-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Rangpur").Id, Name = "Gangachara", NameBn = "গঙ্গাচরা" },

            // Dinajpur District
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Dinajpur Sadar", NameBn = "দিনাজপুর সদর" },
            new() { Id = new Guid("aa000053-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Dinajpur").Id, Name = "Parbatipur", NameBn = "পার্বতীপুর" },

            // Thakurgaon District
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Thakurgaon Sadar", NameBn = "ঠাকুরগাঁও সদর" },
            new() { Id = new Guid("aa000054-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Thakurgaon").Id, Name = "Pirganj", NameBn = "পীরগঞ্জ" },

            // Kurigram District
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Kurigram Sadar", NameBn = "কুড়িগ্রাম সদর" },
            new() { Id = new Guid("aa000055-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Kurigram").Id, Name = "Nageshwari", NameBn = "নাগেশ্বরী" },

            // Gaibandha District
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Gaibandha Sadar", NameBn = "গাইবান্ধা সদর" },
            new() { Id = new Guid("aa000056-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Gaibandha").Id, Name = "Sundarganj", NameBn = "সুন্দরগঞ্জ" },

            // Lalmonirhat District
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Lalmonirhat Sadar", NameBn = "লালমনিরহাট সদর" },
            new() { Id = new Guid("aa000057-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Lalmonirhat").Id, Name = "Aditmari", NameBn = "আদিতমারী" },

            // Nilphamari District
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Nilphamari Sadar", NameBn = "নীলফামারী সদর" },
            new() { Id = new Guid("aa000058-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Nilphamari").Id, Name = "Saidpur", NameBn = "সৈদপুর" },

            // Panchagarh District
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Panchagarh Sadar", NameBn = "পঞ্চগড় সদর" },
            new() { Id = new Guid("aa000059-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Panchagarh").Id, Name = "Tetulia", NameBn = "তেতুলিয়া" },

            // Mymensingh District
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Mymensingh Sadar", NameBn = "ময়মনসিংহ সদর" },
            new() { Id = new Guid("aa000060-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Mymensingh").Id, Name = "Trishal", NameBn = "ত্রিশাল" },

            // Jamalpur District
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Jamalpur Sadar", NameBn = "জামালপুর সদর" },
            new() { Id = new Guid("aa000061-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Jamalpur").Id, Name = "Melandaha", NameBn = "মেলান্দহ" },

            // Sherpur District
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Sherpur Sadar", NameBn = "শেরপুর সদর" },
            new() { Id = new Guid("aa000062-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Sherpur").Id, Name = "Nalitabari", NameBn = "নালিতাবাড়ী" },

            // Netrokona District
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000001"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Netrokona Sadar", NameBn = "নেত্রকোণা সদর" },
            new() { Id = new Guid("aa000063-0000-4000-8000-000000000002"), DistrictId = districts.First(d => d.Name == "Netrokona").Id, Name = "Kalmakanda", NameBn = "কালমাকান্দা" }
        };
    }
}
