namespace PartyManagement.Domain.Parties.States
{
    public class RejectedState : PartyState
    {
        public override PartyState Revise()
        {
            return new WaitingForActivationState();
        }
    }
}