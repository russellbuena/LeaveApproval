namespace Leaves.Data.Entities
{
    internal interface IApprovalLeaveForm
    {
        bool ScrumMasterApproved(int scrumMasterEmployeeId);
        bool ScrumMasterRejected(int scrumMasterEmployeeId);

        bool HumanResourceDeptApproved(int hrStaffEmployeeId);
        bool HumanResourceDeptRejected(int hrStaffEmployeeId);
    }
}