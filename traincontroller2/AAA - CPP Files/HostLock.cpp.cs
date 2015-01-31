// #include "HostLock.h"
// 
// // Using wxWidgets for locks
// 
// #include "wx/wx.h"
// #define LOCK_TYPE   wxCriticalSection
// 
// HostLock::HostLock()
// {
//         _lock = new wxCriticalSection();
// }
// 
// 
// HostLock::~HostLock()
// {
//         delete _lock;
// }
// 
// void    HostLock::Lock()
// {
//         ((LOCK_TYPE *)_lock)->Enter();
// }
// 
// void    HostLock::Unlock()
// {
//         ((LOCK_TYPE *)_lock)->Leave();
// }
// 
