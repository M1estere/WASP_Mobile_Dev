namespace Third_Homework
{
    public interface IStoreItem
    {
        double Price { get; set; }

        void DiscountPrice(int percent);
    }
    
    internal class Disk : IStoreItem
    {
        public string Name { get; protected set; }
        public string Genre { get; protected set; }
        protected int BurnCount { get; set; }

        internal virtual int DiskSize { get; }
        public double Price { get; set; }

        internal Disk(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }

        internal virtual void Burn(params string[] values) { }

        public void DiscountPrice(int percent)
        {
            Price = ((100 - percent) * Price) / 100;
        }
    }
    
    internal class Audio : Disk
    {
        private string _artist;
        private string _recordingStudio;

        private int _songsNumber;

        internal override int DiskSize { get => (_songsNumber * 8); }
        
        internal Audio(string name, string genre, string artist, string recordingStudio, int songsNumber) : base(name, genre)
        {
            _artist = artist;
            _recordingStudio = recordingStudio;
            _songsNumber = songsNumber;
        }

        internal override void Burn(params string[] values)
        {
            if (values.Length < 5)
            {
                Console.WriteLine("!Attention: cannot burn this Audio Disk, too less parameters given!");
                return;
            }
            Console.WriteLine($"!{Name} was burnt with {values[0]} by {values[2]}");
            
            Name = values[0];
            Genre = values[1];
            
            _artist = values[2];
            _recordingStudio = values[3];

            _songsNumber = Convert.ToInt32(values[4]);
            
            BurnCount++;
        }

        public override string ToString()
        {
            return $"Audio Disk:\n\tName: {Name},\n\tGenre: {Genre},\n\tArist: {_artist},\n\t" +
                   $"Recording Studio: {_recordingStudio},\n\tSongs amount: {_songsNumber},\n\tBurns: {BurnCount}";
        }
    }
    
    internal class DVD : Disk
    {
        private string _producer;
        private string _filmCompany;

        private int _minutesCount;

        internal DVD(string name, string genre, string producer, string filmCompany, int minutesCount) : base(name, genre)
        {
            _producer = producer;
            _filmCompany = filmCompany;
            _minutesCount = minutesCount;
        }

        internal override int DiskSize { get => ((_minutesCount / 64) * 2); }

        internal override void Burn(params string[] values)
        {
            if (values.Length < 5)
            {
                Console.WriteLine("!Attention: cannot burn this DVD Disk, too less parameters given!");
                return;
            }
            Console.WriteLine($"!{Name} was burnt with {values[0]} by {values[2]}");
            
            Name = values[0];
            Genre = values[1];
            _producer = values[2];
            _filmCompany = values[3];
            
            _minutesCount = Convert.ToInt32(values[4]);
            
            BurnCount++;
        }

        public override string ToString()
        {
            return $"DVD Disk:\n\tName: {Name},\n\tGenre: {Genre},\n\tProducer: {_producer},\n\t" +
                   $"Film Company: {_filmCompany},\n\tLength: {_minutesCount} min,\n\tBurns: {BurnCount}";
        }
    }
    
    internal class Store
    {
        internal string StoreName { get; }
        internal string Address { get; }

        internal List<Audio> Audios { get; set; } = new List<Audio>();
        internal List<DVD> Films { get; set; } = new List<DVD>();

        public Store(string storeName, string address)
        {
            StoreName = storeName;
            Address = address;
        }

        /* Такой вариант казался круче, чтобы просто писать: store += new Audio();
        public static Store operator +(Store store, Audio newAudio)
        {
            store.Audios.Add(newAudio);

            return store;
        }*/
        
        public static List<Audio> operator +(Store store, Audio newAudio)
        {
            store.Audios.Add(newAudio);

            return store.Audios;
        }

        public static List<Audio> operator -(Store store, Audio audioToRemove)
        {
            if (store.Audios.Contains(audioToRemove) == false) return store.Audios;
            
            store.Audios.Remove(audioToRemove);

            return store.Audios;
        }

        public static List<Audio> operator +(Store store, Audio[] audiosToAdd)
        {
            foreach (Audio audio in audiosToAdd)
            {
                store.Audios.Add(audio);
            }

            return store.Audios;
        }
        
        public static List<Audio> operator -(Store store, Audio[] audiosToAdd)
        {
            foreach (Audio audio in audiosToAdd)
            {
                if (store.Audios.Contains(audio) == false)
                    continue;

                store.Audios.Remove(audio);
            }

            return store.Audios;
        }
        
        public static List<DVD> operator +(Store store, DVD newDvd)
        {
            store.Films.Add(newDvd);

            return store.Films;
        }

        public static List<DVD> operator -(Store store, DVD dvdToRemove)
        {
            if (store.Films.Contains(dvdToRemove) == false) return store.Films;
            
            store.Films.Remove(dvdToRemove);

            return store.Films;
        }
        
        public static List<DVD> operator +(Store store, DVD[] filmsToAdd)
        {
            foreach (DVD dvd in filmsToAdd)
            {
                store.Films.Add(dvd);
            }

            return store.Films;
        }
        
        public static List<DVD> operator -(Store store, DVD[] filmsToRemove)
        {
            foreach (DVD film in filmsToRemove)
            {
                if (store.Films.Contains(film) == false)
                    continue;

                store.Films.Remove(film);
            }

            return store.Films;
        }

        public override string ToString()
        {
            string resultString = "";

            resultString += $"Store: {StoreName} on {Address}\n";
            resultString += "Audios:\n";
            
            int counter = 0;
            foreach (Audio audio in Audios)
            {
                counter++;
                resultString += $"\t{counter}. {audio.Name}, {audio.Genre}";
                resultString += "\n";
            }

            counter = 0;
            resultString += "Films:\n";
            foreach (DVD dvd in Films)
            {
                counter++;
                resultString += $"\t{counter}. {dvd.Name}, {dvd.Genre}";
                resultString += "\n";
            }

            return resultString;
        }
    }
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Store store = new Store("Disks Store", "Baker Street, 221B");
            
            Audio firstAudio = new Audio("80's best hits", "Action", "Greatest Artists", "80's superheroes", 15);
            Audio secondAudio = new Audio("Whaaaaaat the album", "Pop", "Backstreet Boys", "2000's men", 35);
            Audio thirdAudio = new Audio("Best Hits", "Pop", "Maroon 5", "BBC", 15);
            
            DVD firstFilm = new DVD("Godzilla", "Comedy", "Who", "Same shit", 184);
            DVD secondFilm = new DVD("Spider-Man", "Drama", "IDK", "HZ", 123);
            DVD thirdFilm = new DVD("1+1", "Horror", "Don't remember", "Who knows", 147);
            
            store.Audios = store + new Audio[] {firstAudio, secondAudio, thirdAudio};

            store.Films = store + new DVD[] { firstFilm, secondFilm, thirdFilm };
            
            Console.WriteLine(store.ToString());
            Console.WriteLine("\n");
            
            store.Audios[1].Burn("Beat My Soul", "Fighting", "Mike Tyson", "HDStudio", "83");
            store.Films[0].Burn("Mary Poppins", "Fighting", "No Idea", "No Idea x2", "153");
            Console.WriteLine("\n");
            
            store.Films = store - secondFilm;
            store.Audios = store - thirdAudio;
            
            Console.WriteLine($"All disks info of store {store.StoreName} on {store.Address}");
            Console.WriteLine("Audio Disks:\n\tTitle -> Size");

            int counter = 1;
            foreach (Audio storeAudio in store.Audios)
            {
                Console.WriteLine($"\t{counter}. {storeAudio.Name} -> {storeAudio.DiskSize}");
                counter++;
            }

            Console.WriteLine("DVD Disks:\n\tTitle -> Size");
            
            counter = 1;
            foreach (DVD storeDvd in store.Films)
            {
                Console.WriteLine($"\t{counter}. {storeDvd.Name} -> {storeDvd.DiskSize}");
                counter++;
            }
        }
    }
}