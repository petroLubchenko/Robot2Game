using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    class Player
    {
        private Guid id;
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
        }

        public Player(string nickname)
        {
            id = Guid.NewGuid();
            this.nickname = nickname;
        }

        public void StartGame()
        {
            new Game(this).StartGame();
        }

    }
}
