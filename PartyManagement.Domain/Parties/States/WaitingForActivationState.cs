namespace PartyManagement.Domain.Parties.States
{
    public class WaitingForActivationState : PartyState
    {
        public override PartyState Confirm()
        {
            return new ConfirmedState();
        }

        public override PartyState Reject()
        {
            return new RejectedState();
        }
    }
}