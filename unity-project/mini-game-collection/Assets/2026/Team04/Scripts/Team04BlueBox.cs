namespace MiniGameCollection.Games2026.Team04
{
    public class Team04BlueBox : MiniGameBehaviour
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
