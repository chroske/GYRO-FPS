﻿/*******************************************************************************
 * @file    RPC_BTL_Matching_intf_cl.cs
 * @brief   Auto generated by mbrpcgen.rb
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
namespace BTL
{
    /*
     * function ID
     */
    public enum Matching_FuncID
    {
        ID_QUERYCONNECTMATCHING = 0,
        ID_QUERYCONNECTMATCHINGRESULT = 1,
        ID_QUERYHEALTHCHECKMATCHING = 2,
        ID_QUERYHEALTHCHECKMATCHINGRESULT = 3,
        ID_ENTERMATCHINGROOM = 4,
        ID_ENTERMATCHINGROOMRESULT = 5,
        ID_GETMATCHINGSTATUS = 6,
        ID_GETMATCHINGSTATUSRESULT = 7,
        ID_EXITMATCHINGROOM = 8,
        ID_EXITMATCHINGROOMRESULT = 9,
        ID_QUERYDISCONNECTMATCHING = 10,
	    ID_MAX,
    }
	/*
     * max values
     */
    public enum MatchingMaxValues
    {
    }
	/*
     * RPC Stub Interface
     */
    public interface IMatchingClient
    {
        /*
         * Send Funcs
         */
        UInt32 Send_QueryConnectMatching( UInt64 any_key );
        UInt32 Send_QueryConnectMatchingResult( Byte num );
        UInt32 Send_QueryHealthCheckMatching(  );
        UInt32 Send_QueryHealthCheckMatchingResult(  );
        UInt32 Send_EnterMatchingRoom( UInt64 character_id, UInt32 matching_rule, UInt32 matching_value );
        UInt32 Send_GetMatchingStatus( UInt64 matching_room_id );
        UInt32 Send_ExitMatchingRoom( UInt64 character_id, UInt64 matching_room_id );
        UInt32 Send_QueryDisconnectMatching(  );
        /*
         * Receive Funcs
         */
        void Recv_QueryConnectMatching( UInt64 addr, UInt64 any_key );
        void Recv_QueryConnectMatchingResult( UInt64 addr, Byte num );
        void Recv_QueryHealthCheckMatching( UInt64 addr );
        void Recv_QueryHealthCheckMatchingResult( UInt64 addr );
        void Recv_EnterMatchingRoomResult( UInt64 addr, UInt64 matching_room_id, Int32 result );
        void Recv_GetMatchingStatusResult( UInt64 addr, UInt64 matching_room_id, Byte status, BattlePuInfo battle_pu_info );
        void Recv_ExitMatchingRoomResult( UInt64 addr, Int32 result );
        void Recv_QueryDisconnectMatching( UInt64 addr );
    }
}
