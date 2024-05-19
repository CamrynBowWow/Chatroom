using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatroom.Plugins.EFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipientUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ContactList",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserContact = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactList", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_ContactList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conversation",
                columns: new[] { "ConversationId", "RecipientUser", "StartedUser" },
                values: new object[] { 1, new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdatedAt", "Password", "UniqueName" },
                values: new object[] { new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new DateTime(2024, 5, 19, 11, 55, 1, 760, DateTimeKind.Local).AddTicks(3676), "jane@gmail.com", "Jane", "Doe", null, "1234567", "JaneNew" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdatedAt", "Password", "UniqueName" },
                values: new object[] { new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"), new DateTime(2024, 5, 19, 11, 55, 1, 760, DateTimeKind.Local).AddTicks(3663), "joe@gmail.com", "Joe", "Dirt", null, "Password", "JoeDirtie" });

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
                values: new object[] { 1, "Hi, There!", 1, new DateTime(2024, 5, 19, 11, 55, 1, 760, DateTimeKind.Local).AddTicks(3813), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });

            migrationBuilder.CreateIndex(
                name: "IX_ContactList_UserId",
                table: "ContactList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ConversationId",
                table: "Message",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UniqueName",
                table: "User",
                column: "UniqueName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactList");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
