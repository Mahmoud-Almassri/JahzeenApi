namespace JahzeenApi.Domain.Enums
{
    
    public enum UserTypes
    {
        Admin = 1,
        Employee = 2,
        Employer = 3
    }

   
    public enum BaseStatus
    {
        Active = 1,
        NotActive = 2,
        Stuck = 3,
        Returned = 4,
        Switch = 5
    }

    public enum TitleLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Expert = 3
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }

    public enum ApprovalStatus
    {
        submittedForApproval = 1,
        New = 2,
        Approved = 3,
        Decline = 4,
        Rejected = 6
    }

    public enum ActionType
    {
        Submit = 1,
        Accept = 2,
        ReturnForModification = 3,
        ReSubmit = 4,
        Reject = 5,
    }

    public enum WorkFlowStatus
    {
        InProgress = 1,
        Closed = 2,
    }

}
