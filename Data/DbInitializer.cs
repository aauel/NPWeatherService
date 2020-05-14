using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPWeatherService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NPWeatherService.Data
{
    public class DbInitializer
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context = new NPDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<NPDbContext>>())) {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Parks.Any()) {
                    return;   // DB has been seeded
                }

                context.Parks.AddRange(
                    new Park
                    {
                        ParkCode = "ENP",
                        ParkName = "Everglades National Park",
                        State = "Florida",
                        Acreage = 1508538,
                        ElevationInFeet = 0,
                        MilesOfTrail = 35,
                        NumberOfCampsites = 0,
                        Climate = "Tropical",
                        YearFounded = 1934,
                        AnnualVisitorCount = 1110901,
                        EntryFee = 8,
                        NumberOfAnimalSpecies = 760,
                        Latitude = 25.395292M,
                        Longitude = -80.58312M,
                        InspirationalQuote = "There are no other Everglades in the world. They are, they have always been, one of the unique regions of the earth; remote, never wholly known. Nothing anywhere else is like them.",
                        InspirationalQuoteSource = "Marjory Stoneman Douglas",
                        ParkDescription = "The Florida Everglades, located in southern Florida, is one of the largest wetlands in the world. Several hundred years ago, this wetlands was a major part of a 5,184,000 acre watershed that covered almost a third of the entire state of Florida. The Everglades consist of a shallow sheet of fresh water that rolls slowly over the lowlands and through billions of blades of sawgrass. As water moves through the Everglades, it causes the sawgrass to ripple like green waves; this is why the Everglades received the nickname 'River of Grass.'"
                    },
                    new Park
                    {
                        ParkCode = "GCNP",
                        ParkName = "Grand Canyon National Park",
                        State = "Arizona",
                        Acreage = 1217262,
                        ElevationInFeet = 8000,
                        MilesOfTrail = 115,
                        NumberOfCampsites = 120,
                        Climate = "Desert",
                        YearFounded = 1919,
                        AnnualVisitorCount = 4756771,
                        EntryFee = 8,
                        NumberOfAnimalSpecies = 450,
                        Latitude = 36.049680M,
                        Longitude = -112.137700M,
                        InspirationalQuote = "It is the one great wonders. . . every American should see.",
                        InspirationalQuoteSource = "Theodore Roosevelt",
                        ParkDescription = "If there is any place on Earth that puts into perspective the grandiosity of Mother Nature, it is the Grand Canyon. The natural wonder, located in northern Arizona, is a window into the region''s geological and Native American past. As one of the country's first national parks, the Grand Canyon has long been considered a U.S. treasure, and continues to inspire scientific study and puzzlement."
                    },
                    new Park
                    {
                        ParkCode = "GNP",
                        ParkName = "Glacier National Park",
                        State = "Montana",
                        Acreage = 1013322,
                        ElevationInFeet = 6646,
                        MilesOfTrail = 745.6M,
                        NumberOfCampsites = 923,
                        Climate = "Temperate",
                        YearFounded = 1910,
                        AnnualVisitorCount = 2338528,
                        EntryFee = 12,
                        NumberOfAnimalSpecies = 300,
                        Latitude = 48.502380M,
                        Longitude = -113.986600M,
                        InspirationalQuote = "Far away in northwestern Montana, hidden from view by clustering mountain peaks, lies an unmapped corner—the Crown of the Continent.",
                        InspirationalQuoteSource = "George Bird Grinnell",
                        ParkDescription = "Glacier might very well be the most beautiful of America's national parks. John Muir called it 'the best care-killing scenery on the continent.' The mountains are steep, snowcapped, and punctuated by stunning mountain lakes and creeks. Much of the land remains wild and pristine, a result of its remote location and the lack of visitation in the 19th century."
                    },
                    new Park
                    {
                        ParkCode = "GSMNP",
                        ParkName = "Great Smoky Mountains National Park",
                        State = "Tennessee",
                        Acreage = 522419,
                        ElevationInFeet = 6500,
                        MilesOfTrail = 850,
                        NumberOfCampsites = 939,
                        Climate = "Temperate",
                        YearFounded = 1934,
                        AnnualVisitorCount = 10099276,
                        EntryFee = 0,
                        NumberOfAnimalSpecies = 400,
                        Latitude = 35.687150M,
                        Longitude = -83.536850M,
                        InspirationalQuote = "May your trails be crooked, winding, lonesome, dangerous, leading to the most amazing view. May your mountains rise into and above the clouds.",
                        InspirationalQuoteSource = "Edward Abbey",
                        ParkDescription = "The Great Smoky Mountains are a mountain range rising along the Tennessee–North Carolina border in the southeastern United States. They are a subrange of the Appalachian Mountains, and form part of the Blue Ridge Physiographic Province. The range is sometimes called the Smoky Mountains and the name is commonly shortened to the Smokies. The Great Smokies are best known as the home of the Great Smoky Mountains National Park, which protects most of the range. The park was established in 1934, and, with over 9 million visits per year, it is the most-visited national park in the United States."
                    },
                    new Park
                    {
                        ParkCode = "GTNP",
                        ParkName = "Grand Teton National Park",
                        State = "Wyoming",
                        Acreage = 310000,
                        ElevationInFeet = 6800,
                        MilesOfTrail = 200,
                        NumberOfCampsites = 1206,
                        Climate = "Temperate",
                        YearFounded = 1929,
                        AnnualVisitorCount = 2791392,
                        EntryFee = 15,
                        NumberOfAnimalSpecies = 380,
                        Latitude = 43.655479M,
                        Longitude = -110.717941M,
                        InspirationalQuote = "We can not have freedom without wilderness.",
                        InspirationalQuoteSource = "Edward Abbey",
                        ParkDescription = "The peaks of the Teton Range, regal and imposing as they stand nearly 7,000 feet above the valley floor, make one of the boldest geologic statements in the Rockies. Unencumbered by foothills, they rise through steep coniferous forest into alpine meadows strewn with wildflowers, past blue and white glaciers to naked granite pinnacles. The Grand, Middle, and South Tetons form the heart of the range. But their neighbors, especially Mount Owen, Teewinot Mountain, and Mount Moran, are no less spectacular."
                    },
                    new Park
                    {
                        ParkCode = "MRNP",
                        ParkName = "Mount Rainier National Park",
                        State = "Washington",
                        Acreage = 236381,
                        ElevationInFeet = 5500,
                        MilesOfTrail = 260,
                        NumberOfCampsites = 573,
                        Climate = "Rainforest",
                        YearFounded = 1899,
                        AnnualVisitorCount = 1038229,
                        EntryFee = 20,
                        NumberOfAnimalSpecies = 280,
                        Latitude = 46.945915M,
                        Longitude = -121.559280M,
                        InspirationalQuote = "Of all the fire mountains which like beacons, once blazed along the Pacific Coast, Mount Rainier is the noblest.",
                        InspirationalQuoteSource = "Unknown",
                        ParkDescription = "Mt. Rainier National Park is one of three national parks in the state of Washington and is one of America's oldest parks, being one of only five founded in the 19th century. The park was created to preserve one of Americas most spectacular scenic wonders, the snow-capped volcano known as Tahcoma to Indians in ages past and as Mt. Rainier now. While the mountain is unquestionably the centerpiece of the park, its 235,612 acres (378 square miles) also contain mountain ranges, elaborate glaciers, rivers, deep forests, lush meadows covered with wildflowers during the summer, and over 300 miles of trails. 96% of the park is classified as wilderness."
                    },
                    new Park
                    {
                        ParkCode = "RMNP",
                        ParkName = "Rocky Mountain National Park",
                        State = "Colorado",
                        Acreage = 265761,
                        ElevationInFeet = 7800,
                        MilesOfTrail = 300,
                        NumberOfCampsites = 660,
                        Climate = "Woodland",
                        YearFounded = 1915,
                        AnnualVisitorCount = 3176941,
                        EntryFee = 20,
                        NumberOfAnimalSpecies = 360,
                        Latitude = 40.366676M,
                        Longitude = -105.576653M,
                        InspirationalQuote = "It's not the mountain we conquer, but ourselves.",
                        InspirationalQuoteSource = "Sir Edmund Hillary",
                        ParkDescription = "Rocky Mountain National Park is one of the highest national parks in the nation, with elevations from 7,860 feet to 14,259 feet. Sixty mountain peaks over 12,000 feet high result in world-renowned scenery. The Continental Divide runs north - south through the park, and marks a climatic division. Ancient glaciers carved the topography into an amazing range of ecological zones. What you see within short distances at Rocky is similar to the wider landscape changes seen on a drive from Denver to northern Alaska."
                    },
                    new Park
                    {
                        ParkCode = "YNP",
                        ParkName = "Yellowstone National Park",
                        State = "Wyoming",
                        Acreage = 2219791,
                        ElevationInFeet = 8000,
                        MilesOfTrail = 900,
                        NumberOfCampsites = 1900,
                        Climate = "Temperate",
                        YearFounded = 1872,
                        AnnualVisitorCount = 3394326,
                        EntryFee = 15,
                        NumberOfAnimalSpecies = 390,
                        Latitude = 44.134861M,
                        Longitude = -110.666267M,
                        InspirationalQuote = "Yellowstone Park is no more representative of America than is Disneyland.",
                        InspirationalQuoteSource = "John Steinbeck",
                        ParkDescription = "Yellowstone National Park is a protected area showcasing significant geological phenomena and processes. It is also a unique manifestation of geothermal forces, natural beauty, and wild ecosystems where rare and endangered species thrive. As the site of one of the few remaining intact large ecosystems in the northern temperate zone of earth, Yellowstone's ecological communities provide unparalleled opportunities for conservation, study, and enjoyment of large-scale wildland ecosystem processes."
                    },
                    new Park
                    {
                        ParkCode = "YNP2",
                        ParkName = "Yosemite National Park",
                        State = "California",
                        Acreage = 747956,
                        ElevationInFeet = 5000,
                        MilesOfTrail = 800,
                        NumberOfCampsites = 1720,
                        Climate = "Forest",
                        YearFounded = 1890,
                        AnnualVisitorCount = 3882642,
                        EntryFee = 15,
                        NumberOfAnimalSpecies = 420,
                        Latitude = 37.547170M,
                        Longitude = -119.643300M,
                        InspirationalQuote = "Yosemite Valley, to me, is always a sunrise, a glitter of green and golden wonder in a vast edifice of stone and space.",
                        InspirationalQuoteSource = "Ansel Adams",
                        ParkDescription = "Yosemite National Park vividly illustrates the effects of glacial erosion of granitic bedrock, creating geologic features that are unique in the world. Repeated glaciations over millions of years have resulted in a concentration of distinctive landscape features, including soaring cliffs, domes, and free-falling waterfalls. There is exceptional glaciated topography, including the spectacular Yosemite Valley, a 914-meter (1/2 mile) deep, glacier-carved cleft with massive sheer granite walls. These geologic features provide a scenic backdrop for mountain meadows and giant sequoia groves, resulting in a diverse landscape of exceptional natural and scenic beauty."
                    }

                );
                context.SaveChanges();

                context.Surveys.Add(new Survey { ParkCode = "GSMNP", EmailAddress = "amcamarota@yahoo.com", State = State.OH, ActivityLevel = ActivityLevel.Inactive });
                context.SaveChanges();
            }

        }
    }
}
