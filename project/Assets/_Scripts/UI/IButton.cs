namespace Game
{
    public interface IButton
    {
        void Activate();
        public void RedirectedPress() => Activate();
    }
}
