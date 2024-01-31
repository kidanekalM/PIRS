import {BrowserRouter,Routes,Route} from 'react-router-dom'
import SignIn from './Routes/SignIn'
import UserHome from './Routes/home/user_home'
import SignUp from './Routes/SignUp'
import UDashboard from './Routes/user/udashboard'
import CDashboard from './Routes/contractor/cdashboard'
import UProfile from './Routes/user/uprofile'
import CProfile from './Routes/contractor/cprofile'

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
         <Route index path="/" element={<UserHome/>} />
         <Route path="signin" element={<SignIn/>} />
         <Route path="signup" element={<SignUp/>} />
         <Route path="udashboard" element={<UDashboard/>} />
         <Route path="cdashboard" element={<CDashboard/>} />
         <Route path="uprofile" element={<UProfile/>} />
         <Route path="cprofile" element={<CProfile/>} />
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
