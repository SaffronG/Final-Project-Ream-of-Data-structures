namespace Dependencies.Player
{
    internal class MagicSword : IItem
    {
        public string Name { get; set; } = "Magic Sword";
        public string Description { get; set; } = "The sword glows with a brillian blue light and alerts you when monsters are nearby, it also seems to guide itself when you strike.\nYou feel more accurate with this sword!";

        public void Effect(Player player)
        {
            
        }
    }
}
