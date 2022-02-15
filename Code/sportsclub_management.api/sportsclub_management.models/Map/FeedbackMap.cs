using sportsclub_management.models.Requests.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class FeedbackMap
	{
        public Feedback Map(FeedbackUpdateRequest request)
        {
            return new Feedback
            {
                Id = request.Id,
                Add_Feedback = request.Add_Feedback,
                MasterPlayerId = request.MasterPlayerId,
                MasterGameId = request.MasterGameId,
                Modified = System.DateTime.Now
            };
        }
    }
}
