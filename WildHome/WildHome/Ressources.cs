using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace WildHome
{
    public static class Ressources
    {
        public static ContentManager CONTENT;

        public const string PLAYER_TEXTURE = "player";
        public const float GRAVITY = 1.45f;

        public static List<string> OBSTACLES_TEXTURE;

        public static void Initialize()
        {
            OBSTACLES_TEXTURE = new List<string>();
            OBSTACLES_TEXTURE.Add("obstacle");
            OBSTACLES_TEXTURE.Add("sol");
        }
    }
}
