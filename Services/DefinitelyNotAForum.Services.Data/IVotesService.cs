﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinitelyNotAForum.Services.Data
{
    public interface IVotesService
    {
        Task VoteAsync(int postId, string userId, bool isUpVote);

        int GetVotes(int postId);
    }
}
