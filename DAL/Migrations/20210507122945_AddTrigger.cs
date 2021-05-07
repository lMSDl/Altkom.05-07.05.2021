using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE TRIGGER efc.PeopleUpdate ON efc.People
AFTER UPDATE
AS
BEGIN
SET NOCOUNT ON;
 
IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

DECLARE @id INT
SELECT @id = INSERTED.Id
FROM INSERTED

UPDATE efc.People
SET Modified = GETDATE()
WHERE Id = @id
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER efc.PeopleUpdate");
        }
    }
}
