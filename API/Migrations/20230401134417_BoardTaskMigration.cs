using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class BoardTaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATask_Boards_KanBoardId",
                table: "ATask");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Boards_KanBoardId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_KanBoardId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ATask",
                table: "ATask");

            migrationBuilder.DropIndex(
                name: "IX_ATask_KanBoardId",
                table: "ATask");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "KanBoardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ATask");

            migrationBuilder.DropColumn(
                name: "KanBoardId",
                table: "ATask");

            migrationBuilder.RenameTable(
                name: "ATask",
                newName: "ATasks");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserHEXColor",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Boards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Boards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ATasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ATasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "ATasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ATasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ExecutorUserId",
                table: "ATasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequiredRoleId",
                table: "ATasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ATasks",
                table: "ATasks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PersonalTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalTaskOwnerId = table.Column<int>(type: "int", nullable: false),
                    TaskBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserInBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInBoards_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInBoards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardRoleUserInBoard",
                columns: table => new
                {
                    BoardRolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardRoleUserInBoard", x => new { x.BoardRolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BoardRoleUserInBoard_Roles_BoardRolesId",
                        column: x => x.BoardRolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardRoleUserInBoard_UserInBoards_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UserInBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_BoardId",
                table: "ATasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_ExecutorUserId",
                table: "ATasks",
                column: "ExecutorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ATasks_RequiredRoleId",
                table: "ATasks",
                column: "RequiredRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardRoleUserInBoard_UsersId",
                table: "BoardRoleUserInBoard",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_BoardId",
                table: "Roles",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInBoards_BoardId",
                table: "UserInBoards",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInBoards_UserId",
                table: "UserInBoards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_Boards_BoardId",
                table: "ATasks",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_Roles_RequiredRoleId",
                table: "ATasks",
                column: "RequiredRoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ATasks_Users_ExecutorUserId",
                table: "ATasks",
                column: "ExecutorUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_Boards_BoardId",
                table: "ATasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_Roles_RequiredRoleId",
                table: "ATasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ATasks_Users_ExecutorUserId",
                table: "ATasks");

            migrationBuilder.DropTable(
                name: "BoardRoleUserInBoard");

            migrationBuilder.DropTable(
                name: "PersonalTasks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserInBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ATasks",
                table: "ATasks");

            migrationBuilder.DropIndex(
                name: "IX_ATasks_BoardId",
                table: "ATasks");

            migrationBuilder.DropIndex(
                name: "IX_ATasks_ExecutorUserId",
                table: "ATasks");

            migrationBuilder.DropIndex(
                name: "IX_ATasks_RequiredRoleId",
                table: "ATasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserHEXColor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExecutorUserId",
                table: "ATasks");

            migrationBuilder.DropColumn(
                name: "RequiredRoleId",
                table: "ATasks");

            migrationBuilder.RenameTable(
                name: "ATasks",
                newName: "ATask");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KanBoardId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Boards",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Boards",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Boards",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Boards",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ATask",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ATask",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "ATask",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ATask",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ATask",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KanBoardId",
                table: "ATask",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ATask",
                table: "ATask",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KanBoardId",
                table: "Users",
                column: "KanBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_ATask_KanBoardId",
                table: "ATask",
                column: "KanBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ATask_Boards_KanBoardId",
                table: "ATask",
                column: "KanBoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Boards_KanBoardId",
                table: "Users",
                column: "KanBoardId",
                principalTable: "Boards",
                principalColumn: "Id");
        }
    }
}
