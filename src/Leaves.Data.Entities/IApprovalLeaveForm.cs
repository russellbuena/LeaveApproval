namespace Leaves.Data.Entities
{
    internal interface IApprovalLeaveForm
    {
        bool ScrumMasterApproved(int scrumMasterEmployeeId, string currentUsername);
        bool ScrumMasterRejected(int scrumMasterEmployeeId, string currentUsername);

        bool HasFeedbackByScrumMaster();
        bool HasFeedbackByHumanResource();

        bool HumanResourceDeptApproved(int hrStaffEmployeeId, string currentUsername);
        bool HumanResourceDeptRejected(int hrStaffEmployeeId, string currentUsername);
    }
}