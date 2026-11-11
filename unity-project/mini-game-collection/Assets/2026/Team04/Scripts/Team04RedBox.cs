namespace MiniGameCollection.Games2026.Team04
{
    public class Team04RedBox : MiniGameBehaviour
    {
        private void Update()
        {
            if (transform.parent != null)
            {
                transform.localPosition = transform.parent.localPosition;
            }
        }
    }
}
