using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatroom.Plugins.EFCore.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactList_UserId",
                table: "ContactList");

            migrationBuilder.DeleteData(
                table: "ContactList",
                keyColumn: "ContactId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactList",
                keyColumn: "ContactId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conversation",
                keyColumn: "ConversationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"));

            migrationBuilder.CreateIndex(
                name: "IX_ContactList_UserId",
                table: "ContactList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactList_UserId",
                table: "ContactList");

            migrationBuilder.InsertData(
                table: "Conversation",
                columns: new[] { "ConversationId", "RecipientUser", "StartedUser" },
                values: new object[] { 1, new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdatedAt", "Password", "UniqueName" },
                values: new object[] { new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6417), "jane@gmail.com", "Jane", "Doe", new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6414), "1234567", "JaneNew" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdatedAt", "Password", "UniqueName" },
                values: new object[] { new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"), new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6412), "joe@gmail.com", "Joe", "Dirt", new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6393), "Password", "JoeDirtie" });

            migrationBuilder.InsertData(
                table: "ContactList",
                columns: new[] { "ContactId", "UserContact", "UserId" },
                values: new object[] { 1, new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });

            migrationBuilder.InsertData(
                table: "ContactList",
                columns: new[] { "ContactId", "UserContact", "UserId" },
                values: new object[] { 2, new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"), new Guid("7bccb0ba-0050-4f69-9312-906436dda76f") });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "MessageId", "Context", "ConversationId", "Created", "UserId" },
                values: new object[] { 1, "Hi, There!", 1, new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6590), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });

            migrationBuilder.CreateIndex(
                name: "IX_ContactList_UserId",
                table: "ContactList",
                column: "UserId",
                unique: true);
        }
    }
}
