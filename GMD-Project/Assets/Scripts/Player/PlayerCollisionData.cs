namespace Player
{
    public struct PlayerCollisionData
    {
        public bool TouchingGround { get; }
        public bool TouchingCeiling { get; }
        public bool TouchingLeftWall { get; }
        public bool TouchingRightWall { get; }

        public PlayerCollisionData(bool touchingGround, bool touchingCeiling, bool touchingLeftWall, bool touchingRightWall)
        {
            TouchingGround = touchingGround;
            TouchingCeiling = touchingCeiling;
            TouchingLeftWall = touchingLeftWall;
            TouchingRightWall = touchingRightWall;
        }
    }
}