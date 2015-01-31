namespace Traincontroller2 {

  // Using wxWidgets for locks
  using LOCK_TYPE = wxCriticalSection;

  public class HostLock {
    public object _lock;

    public HostLock() {
      _lock = new wxCriticalSection();
    }


    public void Lock() {
      ((LOCK_TYPE)_lock).Enter();
    }

    public void Unlock() {
      ((LOCK_TYPE)_lock).Leave();
    }

  }
}