using System.Text.RegularExpressions;
using SeverSteal.Models;

namespace SeverSteal.FtpsParser
{
    public class LogParser
    {
        private const string RecipientGroup = "recipient";
        private const string SenderGroup = "sender";
        private const string MessageIdGroup = "messageId";
        private const string SubjectGroup = "subject";
        private const string EmailPattern = @"[^\.][a-z0-9\@\.]+";

        public static Conversion Parse(string logData)
        {
            var recipient = Regex.Match(logData, $@"target=(?<{RecipientGroup}>{EmailPattern})", RegexOptions.IgnoreCase).Groups[RecipientGroup].Value;
            var sender = Regex.Match(logData, $@"{SenderGroup}=(?<{SenderGroup}>{EmailPattern})", RegexOptions.IgnoreCase).Groups[SenderGroup].Value;
            var messageId = Regex.Match(logData, $@"messageId_0=(?<{MessageIdGroup}>[a-z0-9\-\@\.]+)", RegexOptions.IgnoreCase).Groups[MessageIdGroup].Value;
            var subject = Regex.Match(logData, $@"{SubjectGroup}=""(?<{SubjectGroup}>.+)"";", RegexOptions.IgnoreCase).Groups[SubjectGroup].Value;
            return new Conversion
            {
                MessageId = messageId,
                Recipient = recipient,
                Sender = sender,
                Subject = subject
            };
        }
    }
}