using System.Text;

namespace MailClient
{
    public class MailBox
    {
        private int capacity;
        private List<Mail> inbox;
        private List<Mail> archive;

        public MailBox (int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }
        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            bool result = false;
            Mail mailFind = Inbox.FirstOrDefault(m => m.Sender == sender);
            if (mailFind is not null)
            {
                Inbox.Remove(mailFind);
                result = true;
            }
            return result;
        }

        public int ArchiveInboxMessages()
        {
            Archive.AddRange(Inbox);
            int mailsArchived = Inbox.Count;
            Inbox = new List<Mail>();
            
            return mailsArchived;
        }

        public string GetLongestMessage()
        {
            Mail longestMail = Inbox.OrderByDescending(m => m.Body).First();

            return longestMail.ToString();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
