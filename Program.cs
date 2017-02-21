using System;
using System.Linq;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using static MotivationBuddy.Menus;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;


namespace MotivationBuddy
{
    internal class Program
    {

        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }
        
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        


        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Motivation buddy loaded!", System.Drawing.Color.Violet);
            Chat.Say("/all Bom jogo");

            Menus.CreateMenu();
            Game.OnTick += Game_OnTick;
            Game.OnNotify += OnGameNotify;
            Game.OnEnd += Game_OnEnd;
        }

        private static void Game_OnEnd(EventArgs args)
        {
            Chat.Say("Bom jogo! Valeu ai");
        }

        private static void Game_OnTick(EventArgs args)
        {
        }

        internal static void OnGameNotify(GameNotifyEventArgs args)
        {
            var Sender = args.NetworkId;

            var Ally = EntityManager.Heroes.Allies.FirstOrDefault(e => e.HealthPercent > 20);
            var AllyD = EntityManager.Heroes.Allies.FirstOrDefault(e => e.HealthPercent < 30);
            var AllyK = EntityManager.Heroes.Allies.LastOrDefault();

            if (FirstMenu["EnableM"].Cast<CheckBox>().CurrentValue)
            {
                switch (args.EventId)
                {
                    case GameEventId.OnChampionKill:
                        if ((Sender == AllyK.NetworkId || Sender == AllyD.NetworkId ) && Sender != myhero.NetworkId)
                        {
                            string[] Motivation1 = { "Boa!", "Mandou bem", "Show", "Mandou muito cara!", "Arrasou","Rexpeita o cara!", "Rx rx rx hehehe", "gj", "wp", "gj wp", "Show de bola", "Destruiu!", "boa mane", "Sinistro!", "Boa!!!!!", "Bora mane!", "Nissu!", "Nice!", "mandou muito bem", "Carrega nois :)", "Carrega nois!!!!", "gg ja!", "Manda muito!", "RX", "eh o QUEIJO!", "eh O Q?", "temos um Djoko hehe", "Oxi!!!!", "Isso ai mane!", "eh pro eh?", "eh o faker hehe :P", "Joga muito!", "Eita ferro", "O loko meu", "Taputo", "Ta putasso", "EOQ", "Segura!!!", "Disseram q tem q elogiar, entao bora: Manda muito!", "Bora sempre ter atitudes positivas!", "honra ae, pls", "Sempre eh bom elogiar", "Posso ser chato, mas nao sou rager", "Ragers nao passarao!", "Aqui eh positividade sempre!", "Bora criar um ambiente sem ragers", "A comunidade precisa de positividade", "Nao sei jogar nao", "To aprendendo ainda", "mal ai, to aprendendo", "nao sei jogar isso nao", "Isso aqui eh mto dificil", "esse bixu pe mto complicado", "To aprendendo, calma ae", "Desculpa qq coisa, to aprendendo"};

                            Random RandName = new Random();
                            string Temp1 = Motivation1[RandName.Next(0, Motivation1.Length)];

                            Core.DelayAction(() => Chat.Say(Temp1), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                        }
                        if (Sender == myhero.NetworkId)
                        {
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Player.DoEmote(Emote.Laugh);

                        }
                        break;
                    case GameEventId.OnChampionDie:
                        if ((Sender == AllyD.NetworkId || Sender == AllyK.NetworkId) && Sender != myhero.NetworkId)
                        {
                            string[] Motivation2 = { "Vamos time!", "relaxa, nos vamos ganhar", "Rlx", "Noobou, cinzou ae hehe :P", "Bora ganhar essa porra", "vamos q vamos, relaxa", "Acontece, relaxa", "Vamos q vamos ae!", "eh so ter pensamento positivo :)", "A gente ganha", "Essa partida eh nossa!", "hora de acabar com eles hein!", "so nao podemos dar mais mole!", "boraganhar hauahua", "eOQ", "soled hehehe", "eoqueijo!", "Circo de.... hehe", "... deitou", "Desculpa, ainda to aprendendo a jogar!", "mal time, ainda to aprendendo os paranaue", "ai ai ai", "ei ei ei", "ei vc ai heheh", "complicado"};

                            Random RandName = new Random();
                            string Temp2 = Motivation2[RandName.Next(0, Motivation2.Length)];

                            Core.DelayAction(() => Chat.Say(Temp2), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                        }
                        break;
                }
            }
            if (FirstMenu["EnableT"].Cast<CheckBox>().CurrentValue)
            {
                var Enemy = EntityManager.Heroes.Enemies.LastOrDefault(e => e.HealthPercent < 30 && !e.IsDead);
                var EnemyD = EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead);
                var EnemyDD = EntityManager.Heroes.Enemies.First();
                var EnemyDDD = EntityManager.Heroes.Enemies.Last();





                switch (args.EventId)
                {
                    case GameEventId.OnChampionDie:
                        if (Sender == Enemy.NetworkId || Sender == EnemyD.NetworkId || Sender == EnemyDD.NetworkId || Sender == EnemyDDD.NetworkId || Sender != myhero.NetworkId)
                        {
                            string[] Tilt2 = { "" };

                            Random RandName = new Random();
                            string Temp2 = Tilt2[RandName.Next(0, Tilt2.Length)];

                            Core.DelayAction(() => Chat.Say(Temp2), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                            Player.DoEmote(Emote.Laugh);
                            Core.DelayAction(() => Chat.Say("/Masterybadge"), FirstMenu["Delay"].Cast<Slider>().CurrentValue);
                        }
                        break;
                }
            }
        }
        


    }
}