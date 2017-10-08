using System;

using System.Collections.Generic;
using Google.Cloud.PubSub.V1;
using MobilePN.Contract;

namespace MobilePN
{

    namespace CampaignDataLoader
    {
        public class CampaignLoaderHelper : CampaignLoaderIf
        {
            protected PubSubHelperIf _pubSubHelper = null;
            public String  ProjectId { get; set; }

            public String  TopicName { get; set; }
            public bool Init(string projectId, string topicName)
            {
                ProjectId = projectId;
                TopicName = topicName;
                _pubSubHelper = new PubSubHelperBase();
                _pubSubHelper.Init(projectId);
                _pubSubHelper.SetTopicName(TopicName);
                return true;
            }

            public bool PushBulk(int bulkSize, List<TargetedUserData> bulkData)
            {
                PublishResponse result = _pubSubHelper.PublishUserDataBulkToPubSub(bulkData, TopicName);
                return true;
            }
        }
    }
}
