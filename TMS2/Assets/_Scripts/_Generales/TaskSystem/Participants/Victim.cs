namespace _Scripts._Generales.TaskSystem.Participants{
    public class Victim : _Scripts.TaskSystem.Tasks.Participants
    {
        private bool quitting;

        public override void Avisar()
        {
            task.TellSomething();
        }

        public override void Interactuar()
        {
            Avisar();
        }

        private void OnApplicationQuit() {
            quitting = true;
        }
        private void OnDestroy()
        {
            if(!quitting)
                Interactuar();
        }
    }
}