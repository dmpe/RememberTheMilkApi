using RememberTheMilkApi.Objects;
using System.Collections.Generic;

namespace RememberTheMilkApi.Helpers
{
    public static class RtmMethodHelper
    {
        internal const string AddTaskMethod = @"rtm.tasks.add";
        internal const string AddTagsMethod = @"rtm.tasks.addTags";
        internal const string GetTasksListMethod = @"rtm.tasks.getList";
        internal const string UndoMethod = @"rtm.transactions.undo";
        internal const string GetListsListMethod = @"rtm.lists.getList";

        public static RtmApiResponse GetListsList() => RtmConnectionHelper.SendRequest(GetListsListMethod, new Dictionary<string, string>());

        public static RtmApiResponse GetTasksList() => RtmConnectionHelper.SendRequest(GetTasksListMethod, new Dictionary<string, string>());

        public static RtmApiResponse GetTasksList(string listId)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"list_id", listId}
            };
            return RtmConnectionHelper.SendRequest(GetTasksListMethod, parameters);
        }

        public static RtmApiResponse AddTask(string timeline, string name, string listId = null, string parse = null, string parentTaskId = null)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"timeline", timeline},
                {"name", name},
            };

            if (listId != null)
            {
                parameters.Add("list_id", listId);
            }

            if (parse != null)
            {
                parameters.Add("parse", parse);
            }

            if (parentTaskId != null)
            {
                parameters.Add("parent_task_id", parentTaskId);
            }

            return RtmConnectionHelper.SendRequest(AddTaskMethod, parameters);
        }

        public static RtmApiResponse AddTags(string timeline, string list_id, string taskseries_id, string task_id, string[] tags)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"timeline", timeline},
                {"list_id ", list_id}
            };

            parameters.Add("taskseries_id", taskseries_id);
            parameters.Add("task_id", task_id);
            parameters.Add("tags", string.Join(string.Empty, tags));

            //tags.ToList().ForEach(Console.WriteLine);
            return RtmConnectionHelper.SendRequest(AddTagsMethod, parameters);
        }

        public static RtmApiResponse UndoTransaction(string timeline, string transactionId)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"timeline", timeline},
                {"transaction_id", transactionId},
            };

            return RtmConnectionHelper.SendRequest(UndoMethod, parameters);
        }
    }
}