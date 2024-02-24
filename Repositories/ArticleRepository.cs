using Classwork_16._02._24_auth_authorization__2.Models;

namespace Classwork_16._02._24_auth_authorization__2.Repositories
{
    public class ArticleRepository
    {
        private readonly List<Article> _articles;
        private readonly UserRepository _userRepository;

        public ArticleRepository(UserRepository userRepository)
        {
            this._userRepository = userRepository;
            var _users = userRepository.Users;

            _articles = new List<Article>()
            {
                new Article{Id = 1,
                    Title = "The Quantum Frontier",
                    Content = "Delve into the fascinating world of quantum mechanics, where particles defy classical intuition and reality takes on a surreal twist. From entanglement to superposition, this article explores the mind-bending concepts shaping the future of computing and communication.",
                    UserId = _users[0].Id},
                new Article{Id = 2,
                    Title = "Rediscovering Ancient Wonders",
                    Content = "Join us on a captivating journey through time as we rediscover ancient wonders that continue to mystify and inspire. From the grandeur of the Pyramids to the enigmatic statues of Easter Island, this article unravels the stories behind these timeless marvels.",
                    UserId = _users[0].Id},
                new Article{Id = 3,
                    Title = "The Art of Mindful Living",
                    Content = "In a fast-paced world, finding moments of tranquility becomes an art. Explore the principles of mindful living, from meditation practices to cultivating gratitude. Discover how embracing mindfulness can bring balance and serenity to your everyday life.",
                    UserId = _users[1].Id},
                new Article{Id = 4,
                    Title = "Beyond the Horizon: Exploring Uncharted Realms",
                    Content = "Venture into the unknown as we embark on a daring expedition beyond familiar horizons. This article takes you on a thrilling odyssey through undiscovered realms, where mysteries abound and the promise of new frontiers beckons. From hidden cultures to untouched landscapes, prepare to be captivated by the allure of uncharted territories.",
                    UserId = _users[1].Id},
                new Article
                {
                    Id = 5,
                    Title = "The Quantum Entanglement Symphony",
                    Content = "Dive deeper into the intricate dance of quantum entanglement, where particles perform a mesmerizing symphony of interconnected states. Unravel the harmony and discord that shape the quantum realm, pushing the boundaries of our understanding.",
                    UserId = _users[2].Id
                },
                new Article
                {
                    Id = 6,
                    Title = "Lost Civilizations: Secrets of the Ancient Maya",
                    Content = "Embark on an archaeological expedition to uncover the secrets of the ancient Maya civilization. From the towering pyramids of Tikal to the mysterious glyphs of Copán, this article reveals the untold stories and cultural richness of a once-thriving civilization.",
                    UserId = _users[2].Id
                },
                new Article
                {
                    Id = 7,
                    Title = "Zen and the Art of Creativity",
                    Content = "Explore the intersection of Zen philosophy and creative expression. This article delves into the practices that cultivate a mindful and creative mindset, allowing individuals to tap into their inner reservoir of inspiration and innovation.",
                    UserId = _users[3].Id
                },
                new Article
                {
                    Id = 8,
                    Title = "Unveiling the Cosmos: Celestial Wonders Beyond Our Imagination",
                    Content = "Peer through the cosmic veil as we unveil celestial wonders that stretch the limits of human imagination. From distant galaxies to awe-inspiring nebulae, this article invites you to journey through the cosmos and ponder the vastness of our universe.",
                    UserId = _users[3].Id
                },
                new Article
                {
                    Id = 9,
                    Title = "The Science of Happiness: A Journey Within",
                    Content = "Embark on a personal journey to uncover the science behind happiness. Delve into the realms of positive psychology, mindfulness, and the pursuit of fulfillment. This article provides insights and practical tips for cultivating joy in everyday life.",
                    UserId = _users[4].Id
                },
                new Article
                {
                    Id = 10,
                    Title = "Magical Realms: Folklore and Fantasy",
                    Content = "Step into the enchanting world of folklore and fantasy, where mythical creatures roam and ancient tales come to life. This article explores the rich tapestry of global folklore, from majestic dragons to mischievous spirits, weaving a tapestry of wonder and imagination.",
                    UserId = _users[4].Id
                },
                 new Article
                {
                    Id = 11,
                    Title = "Eternal Flames: Fire's Mystical Dance",
                    Content = "Witness the mesmerizing dance of flames as we explore the mystical allure of fire. From ancient rituals to modern-day celebrations, this article delves into the symbolism and cultural significance of fire. Immerse yourself in the warmth of stories that span across civilizations, revealing the timeless fascination with the eternal flames that continue to captivate the human spirit.",
                    UserId = _users[0].Id
                },
                new Article
                {
                    Id = 12,
                    Title = "A Symphony of Colors: Artistic Expressions",
                    Content = "Embark on a visual journey through the world of artistic expressions, where colors harmonize to create a symphony for the eyes. Explore the diverse palettes of renowned artists and discover the emotions conveyed through each stroke. This article celebrates the power of color in evoking emotions, telling stories, and transcending cultural boundaries to create a universal language of visual beauty.",
                    UserId = _users[1].Id
                },
                new Article
                {
                    Id = 13,
                    Title = "Whispers of the Forest: Nature's Hidden Stories",
                    Content = "Listen closely to the whispers of the forest as we uncover the hidden stories within nature's embrace. From ancient folklore to modern ecological wonders, this article explores the symbiotic relationships and secrets concealed within lush green landscapes. Immerse yourself in the tranquil beauty of wooded realms, where every rustle and chirp tells a tale of interconnected life thriving beneath the forest canopy.",
                    UserId = _users[2].Id
                },
                new Article
                {
                    Id = 14,
                    Title = "The Culinary Tapestry: Global Gastronomic Delights",
                    Content = "Embark on a culinary odyssey as we unravel the diverse tapestry of global gastronomy. From street markets to haute cuisine, this article explores the rich flavors, techniques, and cultural influences that define regional dishes. Join the culinary journey to savor the unique tastes that reflect the heritage and creativity of chefs worldwide. Immerse yourself in a world where every bite tells a story of culinary excellence and innovation.",
                    UserId = _users[3].Id
                },
                new Article
                {
                    Id = 15,
                    Title = "Sailing the Celestial Seas: Navigating the Night Sky",
                    Content = "Set sail on a celestial voyage as we navigate the night sky, exploring the wonders of stars, constellations, and cosmic phenomena. This article guides you through the art of stargazing, uncovering the myths and scientific marvels that adorn the vast expanse above. Immerse yourself in the cosmic seas, where each star is a beacon of mystery, and the night sky becomes a canvas of celestial stories waiting to be discovered.",
                    UserId = _users[4].Id
                },
                new Article
                {
                    Id = 16,
                    Title = "Echoes of Antiquity: Ancient Musical Instruments",
                    Content = "Discover the echoes of antiquity through the enchanting world of ancient musical instruments. From the haunting melodies of forgotten flutes to the rhythmic beats of ancient drums, this article explores the cultural significance and craftsmanship of musical artifacts. Immerse yourself in the sounds that once resonated through ancient civilizations, connecting people across time through the universal language of music.",
                    UserId = _users[0].Id
                },
                new Article
                {
                    Id = 17,
                    Title = "Architectural Marvels: Bridges Across Continents",
                    Content = "Cross the spans of continents through the lens of architectural marvels, exploring the intricate designs and engineering feats of iconic bridges. From suspended wonders to historic crossings, this article celebrates the artistry and functionality of bridges that connect cultures and redefine landscapes. Immerse yourself in the stories behind these structural masterpieces that stand as testaments to human innovation and the desire to overcome geographical boundaries.",
                    UserId = _users[1].Id
                },
                new Article
                {
                    Id = 18,
                    Title = "Beneath the Waves: Secrets of the Deep Sea",
                    Content = "Dive into the mysteries beneath the waves as we unveil the secrets of the deep sea. From bioluminescent wonders to the hidden realms of underwater ecosystems, this article explores the rich biodiversity and enigmatic creatures that thrive in the ocean's depths. Immerse yourself in the beauty and challenges of marine life, where every discovery reveals the interconnected web of life beneath the surface of the world's oceans.",
                    UserId = _users[2].Id
                },
                new Article
                {
                    Id = 19,
                    Title = "The Poetry of Motion: Dance Across Cultures",
                    Content = "Embark on a global journey through the poetry of motion, exploring the diverse forms of dance that transcend cultural boundaries. From traditional rituals to contemporary expressions, this article celebrates the artistry, storytelling, and emotional resonance of dance. Immerse yourself in the rhythm and grace that define cultural identities, connecting people through the universal language of movement.",
                    UserId = _users[3].Id
                },
                new Article
                {
                    Id = 20,
                    Title = "Mystical Gardens: Botanical Wonders Around the World",
                    Content = "Wander through the enchanting landscapes of mystical gardens, discovering botanical wonders from around the world. This article explores the diverse flora, unique designs, and cultural significance of gardens that captivate the senses. Immerse yourself in the vibrant colors, fragrant blooms, and serene atmospheres that define these havens of natural beauty. Join the journey through mystical gardens that weave tales of horticultural artistry and the enduring connection between humans and nature.",
                    UserId = _users[4].Id
                }
            };
        }

        public List<Article> Articles
        {
            get
            {
                return _articles;
            }
        }

        public Article GetArticleById(int id)
        {
            return _articles.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Article article)
        {
            var current = _articles.FirstOrDefault(e => e.Id == article.Id);
            int index = _articles.IndexOf(current);

            current.Title = article.Title;
            current.Content = article.Content;

            _articles[index] = current;
        }

        public void AddArticle(Article article) {
            _articles.Add(article);
        }

        public void Delete(int id)
        {
            var current = _articles.FirstOrDefault(e => e.Id == id);

            _articles.Remove(current);
        }
    }
}
