﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheldueLogic.SheldueObj
{
    public class Couple
    {
        public bool isEmpty() => subject.Name == "" && subject.GoogleMeetUrl == null;

        public TimeSpan begin;
        public TimeSpan end;
        public Subject subject;

        public int homework;

        public bool isTimeBeforeCouple(TimeSpan time, 
            ref bool NotificatedBeforeCouple,
            ref bool NotificatedAboutCouple,
            ref bool NotificatedHomeworkCouple)
        {
            if (begin.Add(new TimeSpan(0, -5, 0)) < time && time < begin && !NotificatedBeforeCouple)
            {
                NotificatedBeforeCouple = true;
                NotificatedAboutCouple = false;
                NotificatedHomeworkCouple = false;
                return true;
            }
            else return false;
        }
        public bool isTimeAboutCouple(TimeSpan time,
            ref bool NotificatedBeforeCouple,
            ref bool NotificatedAboutCouple,
            ref bool NotificatedHomeworkCouple)
        {
            if (begin < time && time < begin.Add(new TimeSpan(0, 0, 5)) && !NotificatedAboutCouple)
            {
                NotificatedBeforeCouple = false;
                NotificatedAboutCouple = true;
                NotificatedHomeworkCouple = false;
                return true;
            }
            else return false;
        }
        public bool isTimeHomework(TimeSpan time,
            ref bool NotificatedBeforeCouple,
            ref bool NotificatedAboutCouple,
            ref bool NotificatedHomeworkCouple)
        {
            if (end < time && time < end.Add(new TimeSpan(0, 1, 0)) && !NotificatedHomeworkCouple)
            {
                NotificatedBeforeCouple = false;
                NotificatedAboutCouple = false;
                NotificatedHomeworkCouple = true;
                return true;
            }
            else return false;
        }

        public Couple(TimeSpan begin, TimeSpan end, Subject subject, int homework = 0)
        {
            this.begin = begin;
            this.end = end;
            this.subject = subject;
            this.homework = homework;

        }
        public Couple()
        {
        }

        public bool isCoupleFitInTime(TimeSpan time) => ((begin < time) && (time < end));
    }
}