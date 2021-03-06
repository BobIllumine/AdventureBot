﻿using AdventureBot.ObjectManager;

namespace AdventureBot.Room
{
    public class RoomAttribute : IdentifiableAttribute
    {
        public RoomAttribute(string identifier) : base(identifier)
        {
        }
    }

    public class AvailableAttribute : RoomAttribute
    {
        public AvailableAttribute(string identifier, Difficulity difficulity) : base(identifier)
        {
            Difficulity = difficulity;
        }

        public Difficulity Difficulity { get; }
    }
}