import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "./ReportCard/ReportCard";
import UNav from "../../components/user_dashboard/user_nav";
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import Avatar from '@mui/material/Avatar';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
const apiKey = import.meta.env.VITE_API_URL
const appUserId = localStorage.getItem("userId")
export default function Reports(companyId="1", status="0"){

    const [reports,setReports] = useState([]);
    const [hiringCompanies,setHiringCompanies] = useState([])
    const [selectedCompany,setSelectedCompany] = useState({user:{id:""}})
    useEffect(() => {
        fetch(`${apiKey}/Report`)
          .then(response => response.json())
          .then(data => setReports(data));
      }, []);
      useEffect(()=>{
        fetch(`${apiKey}/User/users-with-roles?roleName=Company`)
        .then((response) => response.json())
        .then((response) => {
          setHiringCompanies(response);
          setHiringCompanies(response);
          console.log("asdfafd",hiringCompanies)
        })
        .catch((error) => {
          console.error('Error fetching hiring companies:', error);
        });
      },[])
      const handleCompanySelection = (companyId) => {
        setSelectedCompany(companyId);
        useEffect(() => {
          fetch(`${apiKey}/Report/GetByCompany?id=${company}&reportStatus=${0}`)
            .then((response) => response.json())
            .then((data) => {
              setReports(data);
            })
            .catch((error) => {
              console.error('Error fetching hiring companies:', error);
            });
        }, [])
      };
    
    return<>
    <UNav/>
    <Box display={"flex"} flexDirection='column' width={'90%'} gap='1.5rem' paddingTop={'10px'} paddingBottom={'50px'} className="report mx-5">
    <Box sx={{width:200}}>

    <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Company</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={selectedCompany && selectedCompany.user.id}
          // value={selectedCompany==''? <> <Avatar src={"https://localhost:7077/"+selectedCompany.user.logo}></Avatar> {selectedCompany.user.name}</>:<></>}
          label="Company"
          onChange={(event)=>{handleCompanySelection(event.target.value)}}
          >
          { hiringCompanies.map((company)=>
            <MenuItem value={company.user.id} >
              <Avatar src={apiKey+"/"+company.user.logo}></Avatar>
              {company.user.name}
            </MenuItem>)
          }
        </Select>
      </FormControl>
      </Box>

    {reports.map((r)=>{return <ReportCard report={r} appUserId={appUserId} role="User" onUpvoteClick={()=>{handleUpvote(r)}} onApproveClick={(e)=>{console.log(e)}} onRejectClick={()=>{console.log(r)}}/>})}
    </Box>
    </>
}

function handleUpvote(report){
  console.log(report);
  let upvote = report.upvotes.find((u)=>u.userId==appUserId);
  // Delete
  if(report.upvotes.some((u)=>u.userId==appUserId)){
    fetch(`${apiKey}/Report/Upvote?reportId=${report.reportId}&upvoteId=${upvote.id}`, {
      method: 'DELETE'
    })
  }
  // Create
  else{
    fetch(`${apiKey}/Report/Upvote?reportId=${report.reportId}&userId=${appUserId}`, {
      method: 'POST'
    })
    .then((r)=>r.json())
    .then((r)=>{console.log(r)})
  }
}