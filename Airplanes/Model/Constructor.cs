using System;

namespace Airplanes.Model
{

    [Serializable]
    internal class Construct
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DOC { get; set; }
        public string Maxheight { get; set; }
        public string Color { get; set; }


        public Construct(string name, string type, string doc, string maxheight, string color)
        {
            Name = name;
            Type = type;
            DOC = doc;
            Maxheight = maxheight;
            Color = color;
        }
        public override string ToString()
        {
            return $"\nНазвание: {Name}" +
                $" \nТип самолета: {Type}" +
                $" \nДата создания: {DOC}" +
                $" \nМаксимальная высота: {Maxheight} км" +
                $" \nЦвет раскарски: {Color}";

        }
    }


}
