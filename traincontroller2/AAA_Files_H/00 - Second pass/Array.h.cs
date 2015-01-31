 /*
 
 Copyright (c) 2007-2008 Giampiero Caprino,
 Backer Street Software, Sunnyvale, CA, USA.
 
 This Original Source Code, including accompanying documents, or other related
 items, is being provided by the copyright holder(s) subject to the terms of
 this License. By obtaining, using and/or copying this Original Source Code,
 you agree that you have read, understand, and will comply with the following
 terms and conditions of this License:
 
 Permission to use, copy, modify, merge, distribute, and sublicense derivative
 work ("Derivative Work") based on the Original Source Code and its
 documentation, for any purpose, and without fee or royalty to the copyright
 holder(s) is hereby granted, provided that you include the following on ALL
 copies of the Derivative Work that you make:
 
 Any pre-existing intellectual property disclaimers, notices, or terms and
 conditions.
 
 Notice of any changes or modifications to the Original Source Code,
 including the date the changes were made.
 
 NO REPRESENTATION IS MADE ABOUT THE SUITABILITY OF THIS SOURCE CODE FOR ANY
 PURPOSE. IT IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL
 THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
 
 The name and trademarks of copyright holder(s) may NOT be used in advertising
 or publicity pertaining to the Original Source Code or Derivative Works
 without specific, written prior permission. Title to copyright in the
 Original Source Code and any associated documentation will at all times
 remain with the copyright holders.
 
 */
using System;
using System.Collections;
namespace Traincontroller2 {

  /*
   * Array
   *
   * A Array template that doesn't require the contained classes
   * to implement all operations required by std::Array.
   * This is only used to store sets of pointers to objects.
   * Memory management then becomes very easy since there is no
   * useless instance copying, and another Array can be used to store
   * a pool of allocated objects, making easy to track memory allocation.
   * Objects can then be treated as references.
   * It's also easy to debug and to dump the content of the Array.
   * It may not be very efficient for lots of objects that are frequently
   * created and destroyed. In such cases, use a linked list.
   */


  public class Array<T> where T : class {
    private static int Array_INCREMENT = 128;

    // Erik: disabled this line ==> template <class TT> friend class ArrayIterator;


    // Erik: this was private but they was commented to become public. Change to public in case of errors
    private T[] _instances;		// array of (pointer) instances
    private int _nInstances;		// how many instances are stored in the Array
    private int _maxInstances;		// how many entries can m_instances[] hold (expanded on demand)


    public Array() {
      _nInstances = 0;
      _maxInstances = 0;
      _instances = new T[0];
    }

    ~Array() {
      Release();
    }


    public void Release() {
      if(_instances != null && _instances.Length > 0)
        Globals.delete(_instances);
      _nInstances = 0;
      _maxInstances = 0;
      _instances = null;
    }

    public void Clear() {
      _nInstances = 0;
    }

    //	Add an item to the set

    public void Add(T item) {
      if(_nInstances >= _maxInstances) {
        _maxInstances += Array_INCREMENT;

        if(_instances == null || _instances.Length == 0)
          _instances = new T[_maxInstances];
        else {
          T[] insts = new T[_maxInstances];
          for(int xx = 0; xx < _nInstances; ++xx)
            insts[xx] = _instances[xx];
          Globals.delete(_instances);
          _instances = insts;
        }
        if(_instances == null || _instances.Length == 0)
          Globals.Panic("out of memory");

        // Erik: Disabled following line
        // memset(_instances + _maxInstances - Array_INCREMENT,
        //     0, Array_INCREMENT * sizeof(T));
      }
      _instances[_nInstances++] = item;
    }

    public void Push(T item) {
      Add(item);
    }

    public T Pop() {
      if(_nInstances > 0) {
        --_nInstances;
        return _instances[_nInstances];
      }
      Globals.Panic("pop from an empty stack");
      return _instances[0];
    }

    //	Return item at position 'i'

    public T At(int i) {
      if(i >= _nInstances)
        Globals.Panic("out of bounds access");
      return _instances[i];
    }

    public T this[int i] {
      get {
        if(i >= _nInstances)
          Globals.Panic("out of bounds access");
        return _instances[i];
      }
    }

    public T Last() {
      return At(_nInstances - 1);
    }

    //	Find if 'item' is present in the set

    public int Find(T item) {
      int i;

      if(item == null)
        return -1;

      for(i = _nInstances; --i >= 0; )
        if(item.Equals(_instances[i]))
          return i;
      return -1;
    }

    public void PushIfNotIn(T item) {
      int i;

      if(item == null)
        return;

      for(i = _nInstances; --i >= 0; )
        if(item.Equals(_instances[i]))
          return;
      Add(item);
    }

    //	Remove 'item' from the set (without destroying it)

    public void Remove(T item) {
      RemoveAt(Find(item));
    }

    //	Remove item at position 'i' from the set (without destroying it)

    public void RemoveAt(int i) {
      if(i < 0 || i >= _nInstances)
        return;
      while(i < _nInstances - 1) {
        _instances[i] = _instances[i + 1];
        ++i;
      }
      --_nInstances;
    }

    public void RemoveLast() {
      if(_nInstances > 0)
        --_nInstances;
    }

    //	Insert an item at position 'i', moving all items
    //	from position 'i' to the end.

    public void InsertAt(int i, T item) {
      int x;

      Add(item);	    // make space for one item at the end of the Array
      for(x = Length() - 1; x > i; --x)
        _instances[x] = _instances[x - 1];
      _instances[i] = item;
    }

    //
    //

    public void SetAt(int i, T item) {
      if(i < _nInstances)
        _instances[i] = item;
    }

    //	Delete all objects contained in the Array,
    //	effectively releasing all memory used by the Array.
    //	This can only be called when the Array "owns"
    //	the objects stored in it.

    public void DeleteAll() {
      int i;

      for(i = _nInstances - 1; i >= 0; --i)
        Globals.delete(_instances[i]);
      Release();
    }

    //	Return how many items are currently in the set

    public int Length() {
      return _nInstances;
    }

    //	Allocate enough entries to store 'maxInstances' items.
    //	This is useful when a Array must be copied into another
    //	Array, to avoid unnecessary realloc() calls.

    public void Reserve(int maxInstances) {
      if(_maxInstances >= maxInstances)
        return;
      if(_instances == null || _instances.Length == 0)
        _instances = new T[maxInstances]; //(T *)malloc(maxInstances * sizeof(T));
      else {
        T[] insts = new T[maxInstances];
        for(int xx = 0; xx < _nInstances; ++xx)
          insts[xx] = _instances[xx];
        Globals.delete(_instances);
        _instances = insts;
        //		_instances = (T *)realloc(_instances, maxInstances * sizeof(T));
      }
      if(_instances == null || _instances.Length == 0)
        Globals.Panic("out of memory");
      _maxInstances = maxInstances;
    }

    //	Sort items according to the policy specified by 'sorter'

    public void Sort(IComparer sorter) {
      Array.Sort(_instances, sorter);
    }



    /*
     *  An iterator to hide sequential access to Array elements.
     */

    class ArrayIterator {
      public ArrayIterator(Array<T> Array) {
        _index = 0;
        _Array = Array;
      }

      ~ArrayIterator() {
      }

      public T First() {
        _index = 0;
        if(_Array._nInstances == 0)
          return null;
        return _Array._instances[0];
      }

      public T Last() {
        if(_Array._nInstances == 0)
          return null;
        _index = _Array._nInstances - 1;
        return _Array._instances[_index];
      }

      public T Next() {
        if(_index + 1 < _Array._nInstances)
          return _Array._instances[++_index];
        return null;
      }

      public T Prev() {
        if(_index > 0)
          return _Array._instances[--_index];
        return null;
      }

      private Array<T> _Array;
      private int _index;
    }
  }


  /*
   *  ManagedArray
   *
   *  Automatically destroy objects contained in a Array
   *  when the Array is destroyed.
   */


  public class ManagedArray<T> : Array<T> where T : class {
    public ManagedArray() {
    }

    ~ManagedArray() {
      Clean();
    }


    public void DeleteAt(int pos) {
      if(pos >= base.Length())
        return;

      T item = base.At(pos);
      base.RemoveAt(pos);
      Globals.delete(item);
    }



    public void Clean() {
      base.DeleteAll();
    }
  }
}