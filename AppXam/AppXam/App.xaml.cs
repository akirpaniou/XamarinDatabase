using AppXam.Data;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXam
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "CourseDB.db";
        public static CourseAsyncRepository database;
        public static CourseAsyncRepository Database
        {
            get
            {
                if(database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    if (!File.Exists(dbPath))
                    {
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        using (Stream stream = assembly.GetManifestResourceStream($"AppXam.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
                    database = new CourseAsyncRepository(dbPath);
                }
                return database;
            }
        }


        /*
        public const string DATABASE_NAME = "courses2.db";
        public static CourseAsyncRepository database;
        public static CourseAsyncRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new CourseAsyncRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        */

        /*
        public const string DATABASE_NAME = "courses.db";
        public static CourseRepository database;
        public static CourseRepository Database
        {
            get
            {
                if(database == null)
                {
                    database = new CourseRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        */
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
