﻿using UnityEngine;
using UnityEngine.AI;

namespace Assets.Library.LevelDesign.AI
{
    public abstract class PatrollingAI : MonoBehaviour
    {
        public PatrolState state;
        [HideInInspector] public PatrolStation currentStation = null;

        public Vector3 LastInterestPoint;

        public abstract PatrolPoint getPatrollingPoint();

        public abstract NavMeshAgent getNavMeshAgent();
        public abstract void OnDock();
        public abstract void OnPatrolMoveBegin();


        public void DockToStation()
        {

            state = PatrolState.Stationed;
            OnDock();
        }
        public void Patroll()
        {
            state = PatrolState.Patroling;
            OnPatrolMoveBegin();
        }

        public abstract bool isPlaying();
        public abstract void OnSight();
        public abstract void OffSight();
        public abstract void Alarm();
        public abstract void AlarmEnd();
    }
}