import {BrowserRouter,Routes,Route} from 'react-router-dom'
import Home from './Routes/homepage/home'
import ChooseAccount from './Routes/ChooseAccount'
import ChooseCreateAcc from './Routes/ChooseCreateAcc'
import SignUpAsUser from './Routes/sign_up/SignUpAsUser'
import SignUpAsContractor from './Routes/sign_up/SignUpAsContractor'
import SignUpAsCompany from './Routes/sign_up/SignUpAsCompany'
import SignInAsUser from './Routes/sign_in/SignInAsUser'
import SignInAsContractor from './Routes/sign_in/SignInAsContractor'
import SignInAsCompany from './Routes/sign_in/SignInAsCompany'
import UDashboard from './Routes/user/user_dashboard'
import ContDashboard from './Routes/contractor/contdashboard'
import UProfile from './Routes/user/user_profile'
import ContProfile from './Routes/contractor/ContProfile'
import ContTransaction from './Routes/contractor/ContTransaction'
import ContReports from './Routes/contractor/contReports'
import CreateReport from './Routes/user/create_report'
import MyReports from './Routes/user/my_reports'
import Trending from './Routes/user/trending'
import Layout from './components/cont_dashboard/Layout'
import React from 'react'

function App() {
  return (
    <>
      <BrowserRouter>
      
        
        <Routes>
         <Route index path="/" element={<Home/>} />
         <Route path="choose" element={<ChooseAccount/>} />
         <Route path="choosecreate" element={<ChooseCreateAcc/>} />
         <Route path="signupasuser" element={<SignUpAsUser/>} />
         <Route path="signupascontractor" element={<SignUpAsContractor/>} />
         <Route path="signupascompany" element={<SignUpAsCompany/>} />
         <Route path="signinasuser" element={<SignInAsUser/>} />
         <Route path="signinascontractor" element={<SignInAsContractor/>} />
         <Route path="signinascompany" element={<SignInAsCompany/>} />
         <Route path="udashboard" element={<UDashboard/>} />
         
         <Route path="contdashboard" element={<Layout/>} >
           <Route path="GetReportById" element={<ContReports/>}/>
           <Route path="profile" element={<ContProfile/>} />
           <Route path="Transaction" element={<ContTransaction/>}/>
 
        </Route>
       
         <Route path="uprofile" element={<UProfile/>} />
         
         <Route path="contdashboard/Logout" element={<Home/>}/>
         <Route path="contdashboard/Logout/choose" element={<ChooseAccount/>}/>
         <Route path="contdashboard/Logout/choose/choosecreate" element={<ChooseCreateAcc/>}/>
         <Route path='contdashboard/Logout/choosecreate' element={<ChooseCreateAcc/>}/>
            
         <Route path="createreport" element={<CreateReport/>} />
         <Route path="reports" element={<MyReports/>} />
         <Route path="trending" element={<Trending/>} />
        
        </Routes>
        
          
      </BrowserRouter>
    </>
  )
}

export default App
