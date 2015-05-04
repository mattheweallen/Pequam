using NHibernate;
using NHibernate.Util;
using Pequam.Common;
using Pequam.Common.Security;
using Pequam.Data.Entities;
using Pequam.Data.Exceptions;
using Pequam.Data.QueryProcessors;

namespace Pequam.Data.SqlServer.QueryProcessors
{
    public class AddChallengeQueryProcessor : IAddChallengeQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddChallengeQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
        {
            _session = session;
            _userSession = userSession;
            _dateTime = dateTime;
        }

        public void AddChallenge(Challenge challenge)
        {
            challenge.CreatedDate = _dateTime.UtcNow;
            challenge.Status = _session.QueryOver<Status>().Where(x => x.Name == "Not Started").SingleOrDefault();
            challenge.CreatedBy =
                _session.QueryOver<User>().Where(x => x.UserName == _userSession.Username).SingleOrDefault();

            if (challenge.Participants != null && challenge.Participants.Any())
            {
                for (var i = 0; i < challenge.Participants.Count; ++i)
                {
                    var user = challenge.Participants[i];
                    var persistedUser = _session.Get<User>(user.UserId);
                    if (persistedUser == null)
                    {
                        throw new ChildObjectNotFoundException("User not found");
                    }
                    challenge.Participants[i] = persistedUser;
                }
            }

            _session.SaveOrUpdate(challenge);
        }
    }
}
