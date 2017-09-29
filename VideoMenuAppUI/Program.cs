using System;

namespace VideoMenuAppUI
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;

    using VideoMenuAppBLL;
    using VideoMenuAppBLL.BusinessObjects;

    using VideoMenuAppDAL.Entities;

    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        private static VideoBO video1;

        private static VideoBO video2;

        static void Main()
        {
            video1 = new VideoBO { Title = "First Video", Year = 2003 };
            video2 = new VideoBO { Title = "Second Video", Year = 2009 };

            bllFacade.GetVideoService().CreateVideo(video1);
            bllFacade.GetVideoService().CreateVideo(video2);

            MenuItems();
            ReadLine();
        }

        private static void MenuItems()
        {
            string[] items = { "List of All", "Add", "Edit", "Delete", "Exit" };

            var selection = ShowMenu(items);

            switch (selection)
            {
                case 1:
                    ShowListOfVideos();
                    break;
                case 2:
                    CreateVideos();
                    break;
                case 3:
                    EditVideo();
                    break;
                case 4:
                    DeleteVideo();
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
        }

        private static void EditVideo()
        {
            Console.Clear();
            WriteLine("You chosed to edit a video\n");

            var selectedVideo = SelectedVideo();
            if (selectedVideo != null)
            {
                WriteLine("Please type the title");
                selectedVideo.Title = ReadLine();
                WriteLine("\nPlease type the year");
                int year;
                int.TryParse(ReadLine(), out year);
                selectedVideo.Year = year;
                bllFacade.GetVideoService().UpdateVideo(selectedVideo);

                WriteLine("\nThe video is edited");
                WriteLine("\nGo back to menu - PRESS ENTER");
                ReadLine();
                MenuItems();
            }
            else
            {
                WriteLine("Video not found");
            }
        }

        private static void DeleteVideo()
        {
            Console.Clear();
            WriteLine("you chosed to delete a video\n");
            var selectedVideo = SelectedVideo();
            if (selectedVideo != null)
            {
                bllFacade.GetVideoService().DeleteVideo(selectedVideo.Id);
            }

            WriteLine("\nThe video is deleted");
            WriteLine("\nGo back to menu - PRESS ENTER");
            ReadLine();
            MenuItems();
        }

        private static VideoBO SelectedVideo()
        {
            foreach (var video in bllFacade.GetVideoService().GetAllVideos())
            {
                WriteLine($"ID: {video.Id}  Title: {video.Title}\n");
            }

            WriteLine("Type the ID of the video\n");
            int selection;
            while (!int.TryParse(ReadLine(), out selection))
            {
                WriteLine("Please type a valid ID");
            }

            foreach (var video in bllFacade.GetVideoService().GetAllVideos())
            {
                if (video.Id.Equals(selection))
                {
                    return video;
                }
            }

            return null;
        }

        private static void ShowListOfVideos()
        {
            Console.Clear();
            WriteLine("You chosed a list of all videos\n");

            foreach (var i in bllFacade.GetVideoService().GetAllVideos())
            {
                WriteLine($"ID: {i.Id}  Title: {i.Title}  Year: {i.Year}\n");
            }

            WriteLine("Press 'S' for search or 'ENTER' for menu");
            if (ReadLine().Equals("s"))
            {
                Search();
            }
            MenuItems();

        }

        private static void Search()
        {
            WriteLine("\nSearch at:");

            string searchWord = ReadLine().ToLower();
            bool found = false;

            foreach (var video in bllFacade.GetVideoService().GetAllVideos())
            {
                if (video.Id.ToString().Contains(searchWord) || video.Title.ToLower().Contains(searchWord))
                {
                    WriteLine($"Title: {video.Title}");
                    found = true;
                }
            }

            if (!found)
            {
                WriteLine("\nNo matches");
            }

            WriteLine("\nGo back to menu - PRESS 'ENTER' or 's' for search");
            if (ReadLine().Equals("s"))
            {
                Search();
            }

            MenuItems();
        }

        private static void CreateVideos()
        {
            int selection;
            Console.Clear();
            WriteLine("You chosed to add a video\n");
            WriteLine("How many videos do want to add?");
            int.TryParse(ReadLine(), out selection);

            if (selection == 1)
            {
                bllFacade.GetVideoService().CreateVideo(addVideo());
            }
            else
            {
                List<VideoBO> videos = new List<VideoBO>();

                for (int i = 0; i < selection; i++)
                {
                    videos.Add(addVideo());
                }

                bllFacade.GetVideoService().CreateMoreVideos(videos);
            }


             WriteLine("\nGo back to menu - PRESS Enter");
            ReadLine();
            MenuItems();
        }

        private static VideoBO addVideo()
        {
            Console.Clear();
            
            int year;
            WriteLine("Please type the title of the video");
            var title = ReadLine();
            WriteLine("\nPlease type the year of production");
            int.TryParse(ReadLine(), out year);
            VideoBO newVideo = new VideoBO() { Title = title, Year = year };
            return newVideo;
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.Clear();
            WriteLine("Select what you want to do: \n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                WriteLine($" {i + 1}:  {menuItems[i]}");
            }

            int selected;
            while (!int.TryParse(ReadLine(), out selected) || selected < 1 || selected > 5)
            {
                WriteLine(" You need to select a item from the menulist");
            }

            WriteLine(string.Empty);
            Console.WriteLine("Selection: " + selected);
            WriteLine(" ");
            return selected;
        }

        static void WriteLine(string whatToWrite)
        {
            Console.WriteLine(whatToWrite);
        }

        static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}