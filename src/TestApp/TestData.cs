using Microsoft.Extensions.Logging;

namespace TestApp
{
    internal static class TestData
    {
        private static readonly Random Random = Random.Shared;
        private static readonly string[] AllSentences = new[]
        {
            "Be careful with that butter knife.",
            "Thigh-high in the water, the fisherman’s hope for dinner soon turned to despair.",
            "He wondered if it could be called a beach if there was no sand.",
            "The efficiency with which he paired the socks in the drawer was quite admirable.",
            "Peanuts don't grow on trees, but cashews do.",
            "For the 216th time, he said he would quit drinking soda after this last Coke.",
            "The teens wondered what was kept in the red shed on the far edge of the school grounds.",
            "The paintbrush was angry at the color the artist chose to use.",
            "The tears of a clown make my lipstick run, but my shower cap is still intact.",
            "Mary plays the piano.",
            "His confidence would have bee admirable if it wasn't for his stupidity.",
            "He looked behind the door and didn't like what he saw.",
            "He hated that he loved what she hated about hate.",
            "As he looked out the window, he saw a clown walk by.",
            "The tortoise jumped into the lake with dreams of becoming a sea turtle.",
            "He excelled at firing people nicely.",
            "She borrowed the book from him many years ago and hasn't yet returned it.",
            "She looked into the mirror and saw another person.",
            "Harold felt confident that nobody would ever suspect his spy pigeon.",
            "She used her own hair in the soup to give it more flavor.",
            "When she didn't like a guy who was trying to pick her up, she started using sign language.",
            "You've been eyeing me all day and waiting for your move like a lion stalking a gazelle in a savannah.",
            "Today I dressed my unicorn in preparation for the race.",
            "Boulders lined the side of the road foretelling what could come next.",
            "Seek success, but always be prepared for random cats.",
            "She lived on Monkey Jungle Road and that seemed to explain all of her strangeness.",
            "The clouds formed beautiful animals in the sky that eventually created a tornado to wreak havoc.",
            "I liked their first two albums but changed my mind after that charity gig.",
            "To the surprise of everyone, the Rapture happened yesterday but it didn't quite go as expected.",
            "It's always a good idea to seek shelter from the evil gaze of the sun.",
            "Dolores wouldn't have eaten the meal if she had known what it actually was.",
            "The complicated school homework left the parents trying to help their kids quite confused.",
            "A kangaroo is really just a rabbit on steroids.",
            "I'd always thought lightning was something only I could see.",
            "Everyone was curious about the large white blimp that appeared overnight.",
            "He swore he just saw his sushi move.",
            "Karen realized the only way she was getting into heaven was to cheat.",
            "If any cop asks you where you were, just say you were visiting Kansas.",
            "There are no heroes in a punk rock band.",
            "Nobody loves a pig wearing lipstick.",
            "Today arrived with a crash of my car through the garage door.",
            "Peter found road kill an excellent way to save money on dinner.",
            "She says she has the ability to hear the soundtrack of your life.",
            "The door slammed on the watermelon.",
            "Jim liked driving around town with his hazard lights on.",
            "Mr. Montoya knows the way to the bakery even though he's never been there.",
            "You'll see the rainbow bridge after it rains cats and dogs.",
            "There were white out conditions in the town; subsequently, the roads were impassable.",
            "The murder hornet was disappointed by the preconceived ideas people had of him."
        };

        public static string GetRandomSentence()
        {
            return AllSentences[Random.Next(AllSentences.Length)];
        }

        public static LogLevel GetRandomLogLevel()
        {
            return (LogLevel)Random.Next(1, 6);
        }
    }
}
