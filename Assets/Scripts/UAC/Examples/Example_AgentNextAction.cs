
public class Example_AgentNextAction
{
        private AgentMono agent;
        public void NextActionNoMetaData()
        {
                agent.ActivateNextAction();
        }

        public void NextActionMetaData()
        {
                var turnCount = 5;

                // Defining metaData
                var metaData = new TickMetaData
                {
                        TickCount = turnCount,
                        TickedBy = "Ticker ID",
                        TickerMessage = "A message for debugging purposes"
                };
                
                // Activating next action with metadata
                agent.ActivateNextAction(metaData);
        }
}