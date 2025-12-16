namespace HerdService.Domain.Common;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; }
    int? CreatedBy { get; }
    int? LastModifiedBy { get; }
}
