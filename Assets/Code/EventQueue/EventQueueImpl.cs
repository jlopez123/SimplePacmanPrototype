using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.EventQueue
{
    public class EventQueueImpl : MonoBehaviour
    {
        private Queue<LocalEventData> _currentEvents;
        private Queue<LocalEventData> _nextEvents;


        private Dictionary<EventIds, List<IEventObserver>> _observers;
        
        private List<Tuple<EventIds, IEventObserver>> _observersToRemove;
        
        public static EventQueueImpl Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
            
            _currentEvents = new Queue<LocalEventData>();
            _nextEvents = new Queue<LocalEventData>();

            _observers = new Dictionary<EventIds, List<IEventObserver>>();
            _observersToRemove = new List<Tuple<EventIds, IEventObserver>>();
        }
        private void LateUpdate()
        {
            ProcessEvents();
        }
        private void ProcessEvents()
        {
            var tempCurrentEvents = _currentEvents;
            _currentEvents = _nextEvents;
            _nextEvents = tempCurrentEvents;

            foreach (var currentEvent in _currentEvents)
            {
                ProcessEvent(currentEvent);
            }
            _currentEvents.Clear();
            
            RemoveObservers();
        }

        private void ProcessEvent(LocalEventData eventData)
        {
            if (_observers.ContainsKey(eventData.EventId) == false)
                return;

            foreach (var observer in _observers[eventData.EventId])
            {
                observer.Process(eventData);
            }
        }

        public void EnqueueEvent(LocalEventData eventData)
        {
            _currentEvents.Enqueue(eventData);
        }

        public void Subscribe(EventIds eventId, IEventObserver observer)
        {
            if (!_observers.TryGetValue(eventId, out var eventObservers))
            {
                eventObservers = new List<IEventObserver>();
            }
            eventObservers.Add(observer);
            _observers[eventId] = eventObservers;
        }

        public void UnSubscribe(EventIds eventId, IEventObserver observer)
        {
            if (_observers.TryGetValue(eventId, out var evObservers) == false) return;
            
            _observersToRemove.Add( new Tuple<EventIds,IEventObserver>(eventId, observer) );

            /*
            if (_observers.TryGetValue(eventId, out var eventObservers))
            {
                eventObservers.Remove(observer);
            }*/
        }
        
        private void RemoveObservers()
        {
            if (_observersToRemove.Count <= 0)
                return;

            foreach (var observerToRemove in _observersToRemove)
            {
                if (_observers.TryGetValue(observerToRemove.Item1, out var eventObservers))
                {
                    eventObservers.Remove(observerToRemove.Item2);
                }
            }
        }
    }
}