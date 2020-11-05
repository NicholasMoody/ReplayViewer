using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayViewer.ProfileViewer
{
    class Profile
    {
        List<Score> scores = new List<Score>();

        public Profile()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {

        }

        private Score[] Search(string query)
        {
            List<Score> matches = new List<Score>();
            foreach (Score s in scores)
            {
                if (s.SongTitle.ToLower().StartsWith(query))
                    matches.Add(s);
            }
            return matches.ToArray();
        }
    }
}
