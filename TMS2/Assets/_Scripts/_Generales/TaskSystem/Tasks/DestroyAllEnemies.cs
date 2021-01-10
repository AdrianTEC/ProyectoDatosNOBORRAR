
namespace _Scripts.TaskSystem.Tasks
{
    public class DestroyAllEnemies : GameTask
    {
        //participants[]
        
        public override void Initialize()
        {
        }


        public  override void TellSomething()
        {
            participantsLen--;
            if (participantsLen <= 0)
                CompleteTask();
            
        }
        
        
    }


    
}
