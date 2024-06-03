namespace StateMachine
{
    public abstract class State<TContext>
    {
        public bool StateComplete { get; protected set; }

        public void EnterState(TContext context)
        {
            StateComplete = false;
            OnEnterState(context);
        }
        protected virtual void OnEnterState(TContext context) { }
        public virtual void Update(TContext context) { }
        public virtual void FixedUpdate(TContext context) { }
    }
}