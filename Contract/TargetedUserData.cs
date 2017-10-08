using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MobilePN
{

    namespace Contract
    {
        public class TargetedUserData
        {

            protected String _id = String.Empty;
            protected UserTypeEnum _type = UserTypeEnum.None;
            protected bool _isPersonalized = false;
            protected UserPersonalizedData _userPersonalizedData = null;
            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public Dictionary<String, String> PersonalizeValues
            {
                get { return _userPersonalizedData.PersonalizedValues; }

            }

            [JsonIgnore]
            public UserTypeEnum UserType
            {
                get { return _type; }
                set { _type = value; }
            }

            public TargetedUserData(string id, UserTypeEnum type, bool isPersonalized, bool hasPersonalizedData)
            {
                
                _id = id;
                _type = type;
                _isPersonalized = isPersonalized;

                if ( true)
                {
                    _userPersonalizedData = new UserPersonalizedData();
                }
            }

            public bool SetPersonalizedData(UserPersonalizedData data)
            {


                bool status = true;

                _userPersonalizedData = data;

                return status;
            }

            public bool AddPersonalizedData(UserPersonalizedData addedData)
            {


                bool status = true;

                _userPersonalizedData.AddPersonalizedData(ref addedData);

                return status;
            }


            public bool SetPersonalizedValue(String key, String value)
            {


                bool status = true;



                _userPersonalizedData.SetPersonalizedValue(key, value);

                return status;
            }



            public bool RemovePersonalizedValue(String key, String value)
            {


                bool status = true;
                _userPersonalizedData.RemovePersonalizedValue(key, value);

                return status;
            }


            public String SerializeTargetUserToJson()
            {
                string json = JsonConvert.SerializeObject(this);
                return json;
            }


        }

    }
}