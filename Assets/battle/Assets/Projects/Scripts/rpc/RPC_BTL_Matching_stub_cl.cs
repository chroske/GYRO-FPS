﻿/*******************************************************************************
 * @file	RPC_BTL_Matching_intf_cl.cs
 * @brief	Auto generated by mbrpcgen.rb
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
namespace BTL {
	public partial class PU_Client : mln.RPCBasePU
            , IBattleClient
            , IBattlePuListClient
            , IMatchingClient
    {
        // return 0 if error or next
        public UInt32 Receive_Matching( UInt64 conid, UInt32 type, UInt16 totalSize, mln.EndianStream rStream )
        {
		    UInt32 ofs = 0;
            switch (type)
            {
                case (Int32)Matching_FuncID.ID_QUERYCONNECTMATCHING: // 0 
                    {
						// ARGUMENTS
						// ARG 0 : UInt64 any_key
						UInt64 any_key;
						// BASIC TYPE 
						rStream.get(out any_key);
						ofs += (8);
						// RECEIVE CALL 
						Recv_QueryConnectMatching( conid, 
							any_key 
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_QUERYCONNECTMATCHINGRESULT: // 1 
                    {
						// ARGUMENTS
						// ARG 0 : Byte num
						Byte num;
						// BASIC TYPE 
						rStream.get(out num);
						ofs += (1);
						// RECEIVE CALL 
						Recv_QueryConnectMatchingResult( conid, 
							num 
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_QUERYHEALTHCHECKMATCHING: // 2 
                    {
						// ARGUMENTS
						// RECEIVE CALL 
						Recv_QueryHealthCheckMatching( conid
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_QUERYHEALTHCHECKMATCHINGRESULT: // 3 
                    {
						// ARGUMENTS
						// RECEIVE CALL 
						Recv_QueryHealthCheckMatchingResult( conid
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_ENTERMATCHINGROOMRESULT: // 5 
                    {
						// ARGUMENTS
						// ARG 0 : UInt64 matching_room_id
						UInt64 matching_room_id;
						// BASIC TYPE 
						rStream.get(out matching_room_id);
						ofs += (8);
						// ARG 1 : Int32 result
						Int32 result;
						// BASIC TYPE 
						rStream.get(out result);
						ofs += (4);
						// RECEIVE CALL 
						Recv_EnterMatchingRoomResult( conid, 
							matching_room_id ,
							result 
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_GETMATCHINGSTATUSRESULT: // 7 
                    {
						// ARGUMENTS
						// ARG 0 : UInt64 matching_room_id
						UInt64 matching_room_id;
						// BASIC TYPE 
						rStream.get(out matching_room_id);
						ofs += (8);
						// ARG 1 : Byte status
						Byte status;
						// BASIC TYPE 
						rStream.get(out status);
						ofs += (1);
						// ARG 2 : BattlePuInfo battle_pu_info
						BattlePuInfo battle_pu_info = new BattlePuInfo();
						// STRUCT TYPE 
							ofs += BattlePuInfo.get( rStream, battle_pu_info );
						// RECEIVE CALL 
						Recv_GetMatchingStatusResult( conid, 
							matching_room_id ,
							status ,
							battle_pu_info 
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_EXITMATCHINGROOMRESULT: // 9 
                    {
						// ARGUMENTS
						// ARG 0 : Int32 result
						Int32 result;
						// BASIC TYPE 
						rStream.get(out result);
						ofs += (4);
						// RECEIVE CALL 
						Recv_ExitMatchingRoomResult( conid, 
							result 
						);
						break;
					}
                case (Int32)Matching_FuncID.ID_QUERYDISCONNECTMATCHING: // 10 
                    {
						// ARGUMENTS
						// RECEIVE CALL 
						Recv_QueryDisconnectMatching( conid
						);
						break;
					}
			}
			return ofs;
        }
		// Send Funcs
		public UInt32 Send_QueryConnectMatching( UInt64 any_key )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_QueryConnectMatching: start") );
		// check send size 
			// BASIC TYPE 
			totalSize += ( 8 );
			//if( totalSize > left ) ERROR_RETURN(0);
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_QUERYCONNECTMATCHING;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			sendEs.put(any_key);
			//RPCPRINT( "Send_QueryConnectMatching: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_QueryConnectMatchingResult( Byte num )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_QueryConnectMatchingResult: start") );
		// check send size 
			// BASIC TYPE 
			totalSize += ( 1 );
			//if( totalSize > left ) ERROR_RETURN(0);
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_QUERYCONNECTMATCHINGRESULT;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			sendEs.put(num);
			//RPCPRINT( "Send_QueryConnectMatchingResult: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_QueryHealthCheckMatching(  )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_QueryHealthCheckMatching: start") );
		// check send size 
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_QUERYHEALTHCHECKMATCHING;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			//RPCPRINT( "Send_QueryHealthCheckMatching: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_QueryHealthCheckMatchingResult(  )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_QueryHealthCheckMatchingResult: start") );
		// check send size 
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_QUERYHEALTHCHECKMATCHINGRESULT;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			//RPCPRINT( "Send_QueryHealthCheckMatchingResult: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_EnterMatchingRoom( UInt64 character_id, UInt32 matching_rule, UInt32 matching_value )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_EnterMatchingRoom: start") );
		// check send size 
			// BASIC TYPE 
			totalSize += ( 8 );
			//if( totalSize > left ) ERROR_RETURN(0);
			// BASIC TYPE 
			totalSize += ( 4 );
			//if( totalSize > left ) ERROR_RETURN(0);
			// BASIC TYPE 
			totalSize += ( 4 );
			//if( totalSize > left ) ERROR_RETURN(0);
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_ENTERMATCHINGROOM;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			sendEs.put(character_id);
			sendEs.put(matching_rule);
			sendEs.put(matching_value);
			//RPCPRINT( "Send_EnterMatchingRoom: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_GetMatchingStatus( UInt64 matching_room_id )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_GetMatchingStatus: start") );
		// check send size 
			// BASIC TYPE 
			totalSize += ( 8 );
			//if( totalSize > left ) ERROR_RETURN(0);
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_GETMATCHINGSTATUS;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			sendEs.put(matching_room_id);
			//RPCPRINT( "Send_GetMatchingStatus: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_ExitMatchingRoom( UInt64 character_id, UInt64 matching_room_id )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_ExitMatchingRoom: start") );
		// check send size 
			// BASIC TYPE 
			totalSize += ( 8 );
			//if( totalSize > left ) ERROR_RETURN(0);
			// BASIC TYPE 
			totalSize += ( 8 );
			//if( totalSize > left ) ERROR_RETURN(0);
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_EXITMATCHINGROOM;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			sendEs.put(character_id);
			sendEs.put(matching_room_id);
			//RPCPRINT( "Send_ExitMatchingRoom: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public UInt32 Send_QueryDisconnectMatching(  )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID; // PUUID 
			UInt64 conid = 0;
			GetSendID(ref destID, ref srcID, ref conid);
			if( destID == mln.ProcessUnitManager.INVALID_PUUID )
			{
				mln.Utility.MLN_TRACE_LOG("Fail : GetSendID");
				return 0;
			}
				// if( srcID == ProcessUnitManager::INVALID_PUUID ) return 0;
			UInt32 totalSize = 0;
			//RPCPRINT( fprintf(stderr, "Send_QueryDisconnectMatching: start") );
		// check send size 
		// Check size OK  
			mln.EndianStream sendEs = new mln.EndianStream( mln.EndianStream.STREAM_ENDIAN.STREAM_ENDIAN_LITTLE );	// little endian 
			mln.PACKET_HEADER sendHead;
			sendHead.type = (UInt32)Matching_FuncID.ID_QUERYDISCONNECTMATCHING;
			sendHead.dadr = (UInt64)( (UInt64)0<<32 | (UInt64)INTFID.MATCHING );
			sendHead.sadr = conid;
			sendHead.size = (UInt16)totalSize;
		// serialize 
			sendHead.put(sendEs); // serialize head 
			//RPCPRINT( "Send_QueryDisconnectMatching: size %d done", totalSize );
		// send done 
			RPCSendPUBase( sendEs, destID, srcID );
		// finish 
			ClearSendID();
			return totalSize;
		}
		public void Recv_QueryHealthCheckMatching( UInt64 rpc_id )
		{
			EndHealthCheck( rpc_id );
			ResolveSendID( rpc_id );
			Send_QueryHealthCheckMatchingResult();
		}
		public void Recv_QueryHealthCheckMatchingResult( UInt64 rpc_id )
		{
			EndHealthCheck( rpc_id );
		}
		public void Recv_QueryDisconnectMatching( UInt64 rpc_id )
		{
			UInt64 destID = mln.ProcessUnitManager.INVALID_PUUID;
			UInt64 srcID = mln.ProcessUnitManager.INVALID_PUUID;
			UInt64 conid = 0;
			ResolveSendID( rpc_id );
			GetSendID( ref destID, ref srcID, ref conid );
			if ( destID != mln.ProcessUnitManager.INVALID_PUUID ){
				OnDisconnectedRPC( destID, DISCONNECT_STATE.DISCONNECT_STATE_RPC );
			}
		}
	}
} // namespace