import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "./ReportCard/ReportCard";
import UNav from "../../components/user_dashboard/user_nav";
const apiKey = import.meta.env.VITE_API_URL
const appUserId = localStorage.getItem("userId")
export default function Reports(companyId="1", status="0"){

    const [reports,setReports] = useState([]);
    useEffect(() => {
        fetch(`${apiKey}/Report`)
          .then(response => response.json())
          .then(data => setReports(data));
      }, []);
    
    return<>
    <UNav/>
    <Box display={"flex"} flexDirection='column' width={'90%'} gap='1.5rem' paddingTop={'100px'} paddingBottom={'50px'} className="report mx-5">

    {reports.map((r)=>{return <ReportCard report={r} appUserId={companyId} role="User" onUpvoteClick={()=>{handleUpvote(r)}} onApproveClick={(e)=>{console.log(e)}} onRejectClick={()=>{console.log(r)}}/>})}
    </Box>
    </>
}

function handleUpvote(report){
  console.log(report);
  let upvoteId = report.upvotes.find((u)=>u.userId==appUserId);
  // Delete
  if(report.upvotes.some((u)=>{u.userId==appUserId})){
    console.log(upvoteId)
    console.log("Here")
    console.log(report.reportId)
    fetch(`${apiKey}/Report/Upvote?reportId=${report.reportId}&upvoteId=${upvoteId}`, {
      method: 'DELETE'
    })
  }
  // Create
  else{
    fetch(`${apiKey}/Report/Upvote?reportId=${report.reportId}&userId=${appUserId}`)
    .then((r)=>r.json())
    .then((r)=>{console.log(r)})
  }
}