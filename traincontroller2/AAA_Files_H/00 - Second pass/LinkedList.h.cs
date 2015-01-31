 /*	LinkedList.h - Created by Giampiero Caprino
 
 This file is part of Train Director 3
 
 Train Director is free software; you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation; using exclusively version 2.
 It is expressly forbidden the use of higher versions of the GNU
 General Public License.
 
 Train Director is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with Train Director; see the file COPYING.  If not, write to
 the Free Software Foundation, 59 Temple Place - Suite 330,
 Boston, MA 02111-1307, USA.
 */
using System;
namespace Traincontroller2 {
  /*
   * LinkedList
   */
  public class LinkItem<T> where T : class {
    public LinkItem() {
      _next = _prev = null;
    }

    public T _next;
    public T _prev;
  }


  public class LinkedList<T> where T : LinkItem<T> {
    public T _firstItem;
    public T _lastItem;
    int _nItems;

    public LinkedList() {
      _firstItem = _lastItem = null;
      _nItems = 0;
    }

    ~LinkedList() {
      Clear();
    }

    public void Clear() {
      while(_firstItem != null) {
        T obj = _firstItem;
        _firstItem = obj._next;
        Globals.delete(obj);
      }
      _firstItem = _lastItem = null;
      _nItems = 0;
    }

    public T AppendNewItem() {
      throw new NotImplementedException();
      //T obj = new T();
      //if(_firstItem == null)
      //  _firstItem = obj;
      //else
      //  _lastItem._next = obj;
      //obj._prev = _lastItem;
      //_lastItem = obj;
      //return obj;
    }

    public T Remove(T item) {
      throw new NotImplementedException();
      //T next = item._next;
      //if(item._prev != null)
      //  item._prev._next = item._next;
      //else
      //  _firstItem = item._next;
      //if(item._next != null)
      //  item._next.prev = item._prev;
      //else
      //  _lastItem = item._prev;
      //return next;
    }
  }

  public class EventListener : LinkItem<wx.EventListener> {
    public virtual void OnEvent(object list) { }
  }


  public class SynchronizedList<T> : LinkedList<T> where T : LinkItem<T> {
    ~SynchronizedList() { Unlock(); }

    public void AddListener(wx.EventListener l) {
      _listenersLock.Lock();
      _listeners.Add(l);
      _listenersLock.Unlock();
    }

    public void RemoveListener(wx.EventListener l) {
      _listenersLock.Lock();
      _listeners.Remove(l);
      _listenersLock.Unlock();
    }

    public void NotifyListeners() {
      throw new NotImplementedException();
      //_listenersLock.Lock();
      //int i;
      //for(i = 0; i < _listeners.Length(); ++i) {
      //  EventListener l = _listeners.At(i);
      //  l.OnEvent(this);
      //}
      //_listenersLock.Unlock();
    }

    public void Lock() { _lock.Lock(); }
    public void Unlock() { _lock.Unlock(); }
    public HostLock _lock;
    public HostLock _listenersLock;
    public Array<wx.EventListener> _listeners;
  }
}