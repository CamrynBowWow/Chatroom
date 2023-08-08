using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatroom.Plugins.EFCore.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Conversation_ConversationId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ContactList_ContactListContactId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Conversation_ConversationId",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserConversation");

            migrationBuilder.DropIndex(
                name: "IX_User_ContactListContactId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ConversationId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ContactListContactId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ConversationId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientUser",
                table: "Conversation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StartedUser",
                table: "Conversation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserContact",
                table: "ContactList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"),
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6843), new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdatedAt", "Password", "UniqueName" },
                values: new object[] { new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6923), "jane@gmail.com", "Jane", "Doe", new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6845), "1234567", "JaneNew" });

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Conversation_ConversationId",
                table: "Message",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "ConversationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Conversation_ConversationId",
                table: "Message");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"));

            migrationBuilder.DropColumn(
                name: "RecipientUser",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "StartedUser",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "UserContact",
                table: "ContactList");

            migrationBuilder.AddColumn<int>(
                name: "ContactListContactId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConversationId",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UserConversation",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConversation", x => new { x.UserId, x.ConversationId });
                    table.ForeignKey(
                        name: "FK_UserConversation_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConversation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"),
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 7, 23, 9, 42, 464, DateTimeKind.Local).AddTicks(3151), new DateTime(2023, 8, 7, 23, 9, 42, 464, DateTimeKind.Local).AddTicks(3126) });

            migrationBuilder.CreateIndex(
                name: "IX_User_ContactListContactId",
                table: "User",
                column: "ContactListContactId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ConversationId",
                table: "User",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConversation_ConversationId",
                table: "UserConversation",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Conversation_ConversationId",
                table: "Message",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ContactList_ContactListContactId",
                table: "User",
                column: "ContactListContactId",
                principalTable: "ContactList",
                principalColumn: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Conversation_ConversationId",
                table: "User",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "ConversationId");
        }
    }
}
